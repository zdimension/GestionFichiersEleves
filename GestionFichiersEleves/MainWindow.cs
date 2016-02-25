/*
This file is part of GestionFichiersEleves.

GestionFichiersEleves is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

GestionFichiersEleves is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with GestionFichiersEleves.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace GestionFichiersEleves
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Text = "GestionFichiersEleves " + Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
            Helper.SetFont(this, Helper.GetSystemDefaultFont());
            ChargerFichiersParDefaut();
        }

        public void ChargerFichiersParDefaut()
        {
            var bf = Application.StartupPath;
            if(!File.Exists(Path.Combine(bf, "ELEVES.csv")))
                bf = Path.Combine(bf, "Gestion fichiers eleves");

            if (!Directory.Exists(bf)) return;

            rootFolder = bf;

            var feleves = Path.Combine(bf, "ELEVES.csv");
            if (File.Exists(feleves)) fsFichierEleves.FileName = feleves;

            var flivres = Path.Combine(bf, "LIVRES.csv");
            if (File.Exists(flivres)) fsFichierLivres.FileName = flivres;

            var dossierParam = Path.Combine(bf, "Fichiers Parametres");

            var fdivisions = Path.Combine(dossierParam, "Divisions.csv");
            if (File.Exists(fdivisions)) fsDivisions.FileName = fdivisions;

            var fdivex = Path.Combine(dossierParam, "Divisions-exclues.csv");
            if (File.Exists(fdivex)) fsDivisionsExclues.FileName = fdivex;

            var foptex = Path.Combine(dossierParam, "Options-exclues.csv");
            if (File.Exists(foptex)) fsOptionsExclues.FileName = foptex;
        }

        private void fsFichierEleves_SelectedFileChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ChargerFichierEleves(fsFichierEleves.FileName);
            Cursor = Cursors.Default;
        }

        public void ChargerFichierEleves(string f)
        {
            dgvEleves.Clear();

            CSVFichierEleves = FichierCSV.LireFichierCsv(f);
            CSVFichierEleves.RemplirDGV(dgvEleves);
        }

        private FichierCSV CSVFichierEleves;
        private FichierCSV CSVFichierLivres;
        private FichierCSV CSVDivisions;
        private FichierCSV CSVDivisionsExclues;
        private FichierCSV CSVOptionsExclues;

        private void fsFichierLivres_SelectedFileChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ChargerFichierLivres(fsFichierLivres.FileName);
            Cursor = Cursors.Default;
        }

        public void ChargerFichierLivres(string f)
        {
            CSVFichierLivres = FichierCSV.LireFichierCsv(f, true);

            dgvLivres.Clear();

            dgvLivres.Columns.Add("division", "Division");
            dgvLivres.Columns.Add("option", "Option");

            var nbLivres = CSVFichierLivres.Lignes.Max(x => x.Count) - 2;
            for (var i = 1; i <= nbLivres; i++)
            {
                dgvLivres.Columns.Add("livre" + i, "Livre " + i);
            }

            CSVFichierLivres.RemplirDGV(dgvLivres);
        }

        private void fsDivisions_SelectedFileChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ChargerFichierDivisions(fsDivisions.FileName);
            Cursor = Cursors.Default;
        }

        public void ChargerFichierDivisions(string f)
        {
            CSVDivisions = FichierCSV.LireFichierCsv(f);

            dgvDivisions.Clear();

            dgvDivisions.Columns.Add("division", "Division");
            dgvDivisions.Columns.Add("caution", "Caution");
            dgvDivisions.Columns.Add("loc_adhe", "Loc. Adhérent");
            dgvDivisions.Columns.Add("loc_non", "Loc. Non adhérent");

            var nbDiv = CSVDivisions.Lignes.Max(x => x.Count) - 4;
            for (var i = 1; i <= nbDiv; i++)
            {
                dgvDivisions.Columns.Add("division" + i, "Division " + i);
            }

            CSVDivisions.RemplirDGV(dgvDivisions, false);
        }

        private void fsDivisionsExclues_SelectedFileChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ChargerFichierDivisionsExclues(fsDivisionsExclues.FileName);
            Cursor = Cursors.Default;
        }

        public void ChargerFichierDivisionsExclues(string f)
        {
            CSVDivisionsExclues = FichierCSV.LireFichierCsv(f);

            dgvDivisionsExclues.Clear();

            CSVDivisionsExclues.RemplirDGV(dgvDivisionsExclues);
        }

        private void fsOptionsExclues_SelectedFileChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ChargerFichierOptionsExclues(fsOptionsExclues.FileName);
            Cursor = Cursors.Default;
        }

        public void ChargerFichierOptionsExclues(string f)
        {
            CSVOptionsExclues = FichierCSV.LireFichierCsv(f);

            dgvOptionsExclues.Clear();

            CSVOptionsExclues.RemplirDGV(dgvOptionsExclues);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            pbxCurrent.Visible = pbxTotal.Visible = label2.Visible = label4.Visible = true;
            bwMain.RunWorkerAsync();
        }

        private string rootFolder = Application.StartupPath;

        private void creerDossiers()
        {
            var bf = rootFolder;
            while (!Directory.Exists(bf))
                Directory.CreateDirectory(bf);
            var sd = Path.Combine(bf, "Fichiers Divisions");
            while (!Directory.Exists(sd))
                Directory.CreateDirectory(sd);
            var st = Path.Combine(bf, "Fichiers Traitement");
            while (!Directory.Exists(st))
                Directory.CreateDirectory(st);
        }

        private void bwMain_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var sw = new Stopwatch();
                ChangeStatus("Initialisation...");
                Thread.Sleep(1000);
                sw.Start();
                ChangeStatus("Initialisation des fichiers CSV...");

                ChangeProgressBarCurrent(0, 4);

                // Options non trouvées dans le fichier Livres et non présentes dans le fichier Options-exclues.
                var csvOptAnom = new FichierCSV {Colonnes = new List<string> {"Nom", "Prénom", "Division", "Option(s)"}};
                ChangeProgressBarCurrent(1, 4);

                // Division non trouvée dans le fichier Divisions.csv et non présentes dans le fichier Divisions-exclues.
                var csvDivAnom = new FichierCSV {Colonnes = new List<string> {"Nom", "Prénom", "Division"}};
                ChangeProgressBarCurrent(2, 4);

                // Mettre les frères et soeurs dans ce fichier.
                var csvFratries = new FichierCSV {Colonnes = new List<string> {"Nom", "Prénom", "Division"}};
                ChangeProgressBarCurrent(3, 4);

                // Gestion des cas non traités.
                var csvAnomalie = new FichierCSV {Colonnes = CSVFichierEleves.Colonnes};
                ChangeProgressBarCurrent(4, 4);

                ChangeProgressBarTotal(1, 6);
                ChangeProgressBarCurrent(0, 3);
                ChangeStatus("Création des dossiers de sortie...");
                var bf = rootFolder;
                if (!Directory.Exists(bf)) Directory.CreateDirectory(bf);
                ChangeProgressBarCurrent(1, 3);
                var sd = Path.Combine(bf, "Fichiers Divisions");
                if (Directory.Exists(sd))
                    Directory.Delete(sd, true);
                // Une boucle while ici permet de s'assurer que le dossier est bien créé
                while (!Directory.Exists(sd))
                    Directory.CreateDirectory(sd);
                ChangeProgressBarCurrent(2, 3);
                var st = Path.Combine(bf, "Fichiers Traitement");
                if (Directory.Exists(st))
                    Directory.Delete(st, true);
                while (!Directory.Exists(st))
                    Directory.CreateDirectory(st);
                ChangeProgressBarCurrent(3, 3);

                ChangeProgressBarTotal(2, 6);
                ChangeProgressBarCurrent(0, 6);
                ChangeStatus("Génération du fichier des fratries...");

                var etape1 =
                    CSVFichierEleves.Lignes.GroupBy(
                        x => new {NomL1 = x[20], PrenomL1 = x[21], AdresseL1 = x[22], CP = x[24]});
                var etape2 = etape1.Where(x => x.Count() > 1);
                ChangeProgressBarCurrent(5, 6);
                csvFratries.Lignes = etape2.SelectMany(x => x.ToList().AddEmptyLine(x.Max(y => y.Count))).ToList();

                ChangeStatus("Enregistrement du fichier des fratries...");
                csvFratries.Enregistrer(Path.Combine(st, "Fratries.csv"));
                ChangeProgressBarCurrent(6, 6);
                Thread.Sleep(500);
                creerDossiers(); // Acquis de conscience, juste au cas où
                ChangeProgressBarTotal(3, 6);
                ChangeProgressBarCurrent(0, CSVFichierEleves.Lignes.Count);
                ChangeStatus("Génération des fichiers CSV...");
                var csvClasses = new Dictionary<string, FichierCSV>();
                foreach (var d in CSVFichierEleves.Lignes.Select(x => x[8]).Distinct())
                {
                    var csv = new FichierCSV {Colonnes = CSVFichierEleves.Colonnes.ToList()};
                    csv.Colonnes.AddRange(new[] {"Adherent", "Famille", "Delegues", "Caution", "loc_adhe", "Loc_NON"});
                    for (var i = 1; i <= 16; i++)
                    {
                        csv.Colonnes.Add("L" + i.ToString().PadLeft(2, '0'));
                    }
                    csvClasses.Add(d, csv);
                }

                for (var i = 0; i < CSVFichierEleves.Lignes.Count; i++)
                {
                    var curl = CSVFichierEleves.Lignes[i].ToList();
                    try
                    {
                        var div = curl[8];

                        if (string.IsNullOrWhiteSpace(div) || string.IsNullOrWhiteSpace(curl[7]))
                        {
                            csvAnomalie.Lignes.Add(curl);
                            continue;
                        }

                        curl.AddRange(new[] {"", "", ""}); // Adherent, Famille, Delegues (ne pas remplir)


                        var ligneDansFichDiv = CSVDivisions.Lignes.FirstOrDefault(x => x.Skip(4).Contains(div));
                        if (ligneDansFichDiv == null)
                        {
                            if (!CSVDivisionsExclues.Lignes.Any(x => x.Contains(div)))
                            {
                                // Anomalie
                                csvDivAnom.Lignes.Add(new List<string> {curl[0], curl[1], div});
                            }
                            continue;
                        }

                        curl.AddRange(ligneDansFichDiv.GetRange(1, 3));

                        var lignesLivres = CSVFichierLivres.Lignes.Where(x => x[0] == ligneDansFichDiv[0]);

                        foreach (var cli in curl.Skip(9).Take(9))
                        {
                            if (lignesLivres.All(x => x[1] != cli) && !string.IsNullOrWhiteSpace(cli) && cli != "NC")
                            {
                                if (
                                    !CSVOptionsExclues.Lignes.Any(
                                        y => (y[0] == "ALL" || y[0] == ligneDansFichDiv[0]) && y[1] == cli))
                                {
                                    // Anomalie
                                    csvOptAnom.Lignes.Add(new List<string> {curl[0], curl[1], div, cli});
                                }
                            }
                        }

                        curl.AddRange(
                            lignesLivres.Where(
                                x =>
                                    (x[1] == "STD" || curl.Skip(9).Take(9).Contains(x[1])) &&
                                    !CSVOptionsExclues.Lignes.Any(
                                        y => (y[0] == "ALL" || y[0] == ligneDansFichDiv[0]) && y[1] == x[1]))
                                .Select(x => x.Skip(2).Where(y => !string.IsNullOrWhiteSpace(y)))
                                .SelectMany(x => x));

                        csvClasses[div].Lignes.Add(curl);
                    }
                    catch
                    {
                        csvAnomalie.Lignes.Add(curl);
                    }

                    ChangeProgressBarCurrent(i + 1, CSVFichierEleves.Lignes.Count);
                }

                foreach (var kvp in csvClasses)
                {
                    var ligneDansFichDiv = CSVDivisions.Lignes.FirstOrDefault(x => x.Skip(4).Contains(kvp.Key));
                    if (ligneDansFichDiv == null) continue;
                    var lignesLivres = CSVFichierLivres.Lignes.Where(x => x[0] == ligneDansFichDiv[0]);
                    var ligneVide = new List<string>();
                    for (var j = 0; j < 33; j++) ligneVide.Add(".");
                    ligneVide[7] = "";
                    ligneVide[8] = "";
                    ligneVide.AddRange(ligneDansFichDiv.GetRange(1, 3));
                    ligneVide.AddRange(
                        lignesLivres.Select(x => x.Skip(2).Where(y => !string.IsNullOrWhiteSpace(y))).SelectMany(x => x));
                    kvp.Value.Lignes.Add(ligneVide);
                }

                ChangeProgressBarTotal(4, 6);
                ChangeProgressBarCurrent(0, 3);
                ChangeStatus("Enregistrement des fichiers CSV de traitement...");
                Thread.Sleep(200);
                creerDossiers(); // Acquis de conscience, juste au cas où
                csvOptAnom.Enregistrer(Path.Combine(st, "Options-anomalies.csv"));
                ChangeProgressBarCurrent(1, 4);

                csvDivAnom.Enregistrer(Path.Combine(st, "Divisions-anomalies.csv"));
                ChangeProgressBarCurrent(2, 4);

                csvAnomalie.Enregistrer(Path.Combine(st, "Anomalies.csv"));
                ChangeProgressBarCurrent(3, 4);

                ChangeProgressBarTotal(5, 6);
                ChangeProgressBarCurrent(0, csvClasses.Count);
                ChangeStatus("Enregistrement des fichiers CSV des divisions...");

                var csvClassesL = csvClasses.ToList();
                for (var i = 0; i < csvClassesL.Count; i++)
                {
                    var it = csvClassesL[i];
                    if (it.Value.Lignes.Count == 0) continue;
                    it.Value.Enregistrer(Path.Combine(sd, it.Value.Lignes[0][7] + ".csv"));

                    ChangeProgressBarCurrent(i + 1, csvClassesL.Count);
                }

                ChangeProgressBarTotal(6, 6);
                ChangeProgressBarCurrent(100, 100);
                ChangeStatus("Terminé");
                sw.Stop();
                if (MessageBox.Show(
                    "Génération terminée.\nTemps total écoulé : " + sw.Elapsed + " secondes." +
                    "\n\nVoulez-vous ouvrir le dossier de sortie ?", "Génération terminée", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Process.Start(bf);
                }
            }
            catch (Exception ex)
            {
                ChangeProgressBarTotal(6, 6);
                ChangeProgressBarCurrent(100, 100);
                ChangeStatus("Erreur");

                Helper.ShowExceptionMessage(ex);
            }
        }

        public void ChangeProgressBarCurrent(int val, int max)
        {
            if (pbxCurrent.InvokeRequired)
                pbxCurrent.Invoke((MethodInvoker) (() =>
                {
                    pbxCurrent.Maximum = max;
                    pbxCurrent.Value = val;
                }));
            else
            {
                pbxCurrent.Maximum = max;
                pbxCurrent.Value = val;
            }
        }

        public void ChangeProgressBarTotal(int val, int max)
        {
            if (pbxTotal.InvokeRequired)
                pbxTotal.Invoke((MethodInvoker) (() =>
                {
                    pbxTotal.Maximum = max;
                    pbxTotal.Value = val;
                }));
            else
            {
                pbxTotal.Maximum = max;
                pbxTotal.Value = val;
            }
        }

        public void ChangeStatus(string stat)
        {
            if (lblStatus.InvokeRequired) lblStatus.Invoke((MethodInvoker) (() => lblStatus.Text = stat));
            else lblStatus.Text = stat;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "GestionFichiersEleves " + Assembly.GetExecutingAssembly().GetName().Version.ToString(2) + "\n" +
                "Copyright © Tom Niget (zdimension) 2016\n\n" +
                "GestionFichiersEleves est un logiciel développé par Tom Niget (moi), élève en classe de 2°6 du lycée " +
                "Guillaume Fichet de Bonneville, pour l'Association des Parents d'Élèves de Bonneville (APEB), dans le " +
                "cadre du cours ICN (Informatique et Création Numérique).\n\nEn cas de problème n'hésitez pas à me " +
                "contacter à l'adresse e-mail suivante :\nzippedfire@free.fr",
                "À propos du logiciel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvEleves_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var dtp = new DateTimePicker();
                dgvEleves.Controls.Add(dtp);
                dtp.Format = DateTimePickerFormat.Short;
                dtp.Value = DateTime.Parse(dgvEleves.CurrentCell.Value.ToString());
                var rect = dgvEleves.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtp.Size = new Size(rect.Width + 1, rect.Height);
                dtp.Location = new Point(rect.X - 1, rect.Y - 1);
                dtp.CloseUp += (o, args) => dtp.Visible = false;
                dtp.TextChanged += (o, args) => dgvEleves.CurrentCell.Value = dtp.Text.ToString();
                dtp.Visible = true;
            }
        }

        private bool eleveModif;
        private bool livresModif;
        private bool divModif;
        private bool divExclModif;
        private bool optExclModif;

        private void dgvEleves_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            eleveModif = true;
        }

        private void dgvLivres_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            livresModif = true;
        }

        private void dgvDivisions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            divModif = true;
        }

        private void dgvDivisionsExclues_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            divExclModif = true;
        }

        private void dgvOptionsExclues_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            optExclModif = true;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
           
            var verifs = new List<Tuple<bool, string, string, FichierCSV>>
            {
                Tuple.Create(eleveModif, "élèves", fsFichierEleves.FileName, FichierCSV.FromDGV(dgvEleves)),
                Tuple.Create(divExclModif, "divisions exclues", fsDivisionsExclues.FileName, FichierCSV.FromDGV(dgvDivisionsExclues)),
                Tuple.Create(optExclModif, "options exclues", fsOptionsExclues.FileName, FichierCSV.FromDGV(dgvOptionsExclues)),
            };
            foreach (var cur in verifs)
            {
                if (cur.Item1)
                {
                    if (
                        MessageBox.Show(
                            "Le fichier des " + cur.Item2 +
                            " a été modifié à l'intérieur de GestionFichierEleves.\nVoulez-vous enregistrer les modifications ?",
                            "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var path = cur.Item3;

                        try
                        {
                            cur.Item4.Enregistrer(path);
                        }
                        catch (Exception ex)
                        {
                            Helper.ShowExceptionMessage(ex);
                        }
                    }
                }
            }
            bool keep = false;

            if (livresModif)
                if (MessageBox.Show(
                    "Le fichier des livres a été modifié à l'intérieur de " +
                    "GestionFichierEleves. Si vous fermez GestionFichierEleves," +
                    " toutes les modifications seront perdues. Voulez-vous vraiment quitter ?", "Attention",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                    keep = true;

            if (divModif && !keep)
                if (MessageBox.Show(
                    "Le fichier des divisions a été modifié à l'intérieur de " +
                    "GestionFichierEleves. Si vous fermez GestionFichierEleves," +
                    " toutes les modifications seront perdues. Voulez-vous vraiment quitter ?", "Attention",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                    keep = true;

            if (!keep)
                e.Cancel = false;
        }
    }
}
