﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionFichiersEleves
{
    public class FichierCSV
    {
        public List<string> Colonnes { get; set; } = new List<string>();

        public List<List<string>> Lignes { get; set; } = new List<List<string>>();

        public static FichierCSV LireCsv(string code, bool skipHeaders = false)
        {
            var newline = Helper.DetecterLigne(code);

            var lignes = code.Split(new[] {newline}, StringSplitOptions.None);

            var resultat = new FichierCSV();
            var i = 0;
            resultat.Colonnes = skipHeaders ? new List<string>() : lignes[i++].Split(Program.SEPARATEUR).ToList();

            //resultat.Lignes = lignes.Skip(1).Select(x => x.Split(Program.SEPARATEUR).ToList()).ToList();

            resultat.Lignes = new List<List<string>>();

            for (; i < lignes.Length; i++)
            {
                var cur = lignes[i];
                if (string.IsNullOrWhiteSpace(cur) || cur.All(x => x == Program.SEPARATEUR))
                {
                    break;
                }
                resultat.Lignes.Add(cur.Split(Program.SEPARATEUR).ToList());
            }

            return resultat;
        }

        public static FichierCSV LireFichierCsv(string file, bool skipHeaders = false)
        {
            try
            {
                return LireCsv(File.ReadAllText(file, Helper.GetEncoding(file)), skipHeaders);
            }
            catch(Exception e)
            {
                MessageBox.Show("Erreur lors du chargement du fichier " + Path.GetFileName(file) + " : " + e.Message +
                                "\n\n" + e.StackTrace);
                throw;
            }
        }

        public void RemplirDGV(DataGridView dgv, bool colonnes = true)
        {
            if (colonnes)
                Colonnes.ForEach(x => dgv.Columns.Add(new DataGridViewTextBoxColumn {HeaderText = x}));

            foreach (var ligne in Lignes)
            {
                dgv.Rows.Add(ligne.ToArray());
            }
        }

        public string GenererCode(char separateur = Program.SEPARATEUR, bool colonnes = true)
        {
            var nl = Environment.NewLine;
            var result = "";

            var nbcol = Colonnes.Count;

            if (colonnes)
                result += string.Join(separateur.ToString(), Colonnes) + nl;

            result += string.Join(nl, Lignes.Select(x => string.Join(separateur.ToString(), x.ToSize(nbcol))));

            return result;
        }

        public void Enregistrer(string fichier)
        {
            File.WriteAllText(fichier, GenererCode(), Encoding.Default);
        }

        public static FichierCSV FromDGV(DataGridView dgv)
        {
            return new FichierCSV
            {
                Colonnes = (from DataGridViewTextBoxColumn column in dgv.Columns
                            select column.HeaderText).ToList(),
                Lignes = (from DataGridViewRow row in dgv.Rows
                          select (from DataGridViewCell cell in row.Cells select cell.Value?.ToString() ?? "").ToList()).ToList()
            };
        }

        public FichierCSV Clone()
        {
            return new FichierCSV {Colonnes = this.Colonnes.ToList(), Lignes = this.Lignes.ToList()};
        }
    }
}
