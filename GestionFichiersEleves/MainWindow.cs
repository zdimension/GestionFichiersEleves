using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
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

        private readonly Dictionary<string, int> _indices = new Dictionary<string, int>
        {
            {"NOM", 0},
            {"PRENOM", 1},
            {"DIV SIECLE", 7},
            {"DIV", 8},
            {"OPTION 1", 9},
            {"NOM L1", 20},
            {"PRENOM L1", 21},
            {"ADRESSE L1", 22},
            {"CP", 24},
            {"NB COL", 29},

            {"NB OPTIONS", 7}
        };

        private readonly Dictionary<int, string> _comments = new Dictionary<int, string>();

        private static readonly string ParamPath = Path.Combine(Application.StartupPath, "parametres.txt");

        private Encoding _encodageParam = Encoding.UTF8;

        private void ChargerParams()
        {
            if (!File.Exists(ParamPath))
            {
                EnregistrerParams();
                MessageBox.Show("Le fichier de paramètres n'a pas été trouvé.\n" +
                                "Il a donc été créé avec les valeurs par défaut.", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            _encodageParam = Helper.GetEncoding(ParamPath);
            var lns = File.ReadAllLines(ParamPath, _encodageParam);
            var j = 0;
            for (var i = 0; i < lns.Length; i++)
            {
                var l = lns[i];
                if (l.Contains('='))
                {
                    var erreur = "";
                    var s = l.Split('=');
                    if (s.Length == 2)
                    {
                        var pn = s[0].ToUpper().Trim();
                        if (_indices.ContainsKey(pn))
                        {
                            var pv = s[1].Trim();
                            var val = -1;
                            if (int.TryParse(pv, out val))
                            {
                                _indices[pn] = val;
                                j++;
                                continue;
                            }
                            else erreur = "Nombre invalide : " + pv;
                        }
                        else erreur = "Paramètre inconnu : " + pn;
                    }
                    else erreur = "Valeur attendue";
                    MessageBox.Show("Erreur à la ligne " + (i + 1) + " : " + erreur, "Erreur", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Commentaire
                    _comments.Add(i, l);
                }
            }
            if (j != _indices.Count)
            {
                MessageBox.Show("Certains paramètres étaient manquants ou invalides.\n" +
                                "Leurs valeurs par défaut ont donc été rétablies.", "Erreur", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            EnregistrerParams();
        }

        private void EnregistrerParams()
        {
            var ps = _indices.Select(x => x.Key + "=" + x.Value).ToList();
            foreach(var d in _comments) ps.Insert(d.Key, d.Value);
            File.WriteAllLines(ParamPath, ps, _encodageParam);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Text = "GestionFichiersEleves " + Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
            Helper.SetFont(this, Helper.GetSystemDefaultFont());
            ChargerParams();
            ChargerFichiersParDefaut();
        }

        public void ChargerFichiersParDefaut()
        {
            var bf = Application.StartupPath;
            if(!File.Exists(Path.Combine(bf, "ELEVES.csv")))
                bf = Path.Combine(bf, "Gestion fichiers eleves");

            if (!Directory.Exists(bf)) return;

            _rootFolder = bf;

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

        private void ChargerFichierEleves(string f)
        {
            dgvEleves.Clear();

            _csvFichierEleves = FichierCsv.LireFichierCsv(f);
            if(_csvFichierEleves.Colonnes.Count != _indices["NB COL"])
            {
                MessageBox.Show(
                    "Le fichier élèves contient " + _csvFichierEleves.Colonnes.Count +
                    " colonnes, alors qu'il devrait normalement en contenir " + _indices["NB COL"] + ". Cela pourrait provoquer des erreurs.",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            _csvFichierEleves.RemplirDgv(dgvEleves);
        }

        private FichierCsv _csvFichierEleves;
        private FichierCsv _csvFichierLivres;
        private FichierCsv _csvDivisions;
        private FichierCsv _csvDivisionsExclues;
        private FichierCsv _csvOptionsExclues;

        private void fsFichierLivres_SelectedFileChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ChargerFichierLivres(fsFichierLivres.FileName);
            Cursor = Cursors.Default;
        }

        private void ChargerFichierLivres(string f)
        {
            _csvFichierLivres = FichierCsv.LireFichierCsv(f, true);

            dgvLivres.Clear();

            dgvLivres.Columns.Add("division", "Division");
            dgvLivres.Columns.Add("option", "Option");

            var nbLivres = _csvFichierLivres.Lignes.Max(x => x.Count) - 2;
            for (var i = 1; i <= nbLivres; i++)
            {
                dgvLivres.Columns.Add("livre" + i, "Livre " + i);
            }

            _csvFichierLivres.RemplirDgv(dgvLivres);
        }

        private void fsDivisions_SelectedFileChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ChargerFichierDivisions(fsDivisions.FileName);
            Cursor = Cursors.Default;
        }

        private void ChargerFichierDivisions(string f)
        {
            _csvDivisions = FichierCsv.LireFichierCsv(f);

            dgvDivisions.Clear();

            dgvDivisions.Columns.Add("division", "Division");
            dgvDivisions.Columns.Add("caution", "Caution");
            dgvDivisions.Columns.Add("loc_adhe", "Loc. Adhérent");
            dgvDivisions.Columns.Add("loc_non", "Loc. Non adhérent");

            var nbDiv = _csvDivisions.Lignes.Max(x => x.Count) - 4;
            for (var i = 1; i <= nbDiv; i++)
            {
                dgvDivisions.Columns.Add("division" + i, "Division " + i);
            }

            _csvDivisions.RemplirDgv(dgvDivisions, false);
        }

        private void fsDivisionsExclues_SelectedFileChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ChargerFichierDivisionsExclues(fsDivisionsExclues.FileName);
            Cursor = Cursors.Default;
        }

        private void ChargerFichierDivisionsExclues(string f)
        {
            _csvDivisionsExclues = FichierCsv.LireFichierCsv(f);

            dgvDivisionsExclues.Clear();

            _csvDivisionsExclues.RemplirDgv(dgvDivisionsExclues);
        }

        private void fsOptionsExclues_SelectedFileChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ChargerFichierOptionsExclues(fsOptionsExclues.FileName);
            Cursor = Cursors.Default;
        }

        private void ChargerFichierOptionsExclues(string f)
        {
            _csvOptionsExclues = FichierCsv.LireFichierCsv(f);

            dgvOptionsExclues.Clear();

            _csvOptionsExclues.RemplirDgv(dgvOptionsExclues);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var required = new List<string>();
            if(_csvDivisions == null) required.Add("Divisions");
            if(_csvFichierEleves == null) required.Add("Élèves");
            if(_csvFichierLivres == null) required.Add("Livres");
            if (required.Count > 0)
            {
                MessageBox.Show(
                    "Les fichiers suivants sont requis :\n" + string.Join("\n", required.Select(x => "• " + x)),
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pbxCurrent.Visible = pbxTotal.Visible = label2.Visible = label4.Visible = true;
            bwMain.RunWorkerAsync();
        }

        private string _rootFolder = Application.StartupPath;

        private void CreerDossiers()
        {
            var bf = _rootFolder;
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
                var csvOptAnom = new FichierCsv {Colonnes = new List<string> {"Nom", "Prénom", "Division", "Option(s)"}};
                ChangeProgressBarCurrent(1, 4);

                // Division non trouvée dans le fichier Divisions.csv et non présentes dans le fichier Divisions-exclues.
                var csvDivAnom = new FichierCsv {Colonnes = new List<string> {"Nom", "Prénom", "Division"}};
                ChangeProgressBarCurrent(2, 4);

                // Mettre les frères et soeurs dans ce fichier.
                var csvFratries = new FichierCsv {Colonnes = new List<string> {"Nom", "Prénom", "Division"}};
                ChangeProgressBarCurrent(3, 4);

                // Gestion des cas non traités.
                var csvAnomalie = new FichierCsv {Colonnes = _csvFichierEleves.Colonnes};
                ChangeProgressBarCurrent(4, 4);

                ChangeProgressBarTotal(1, 6);
                ChangeProgressBarCurrent(0, 3);
                ChangeStatus("Création des dossiers de sortie...");
                var bf = _rootFolder;
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
                    _csvFichierEleves.Lignes.GroupBy(
                        x => new {NomL1 = x[_indices["NOM L1"]], PrenomL1 = x[_indices["PRENOM L1"]], AdresseL1 = x[_indices["ADRESSE L1"]], CP = x[_indices["CP"]]});
                var etape2 = etape1.Where(x => x.Count() > 1);
                ChangeProgressBarCurrent(5, 6);
                csvFratries.Lignes = etape2.SelectMany(x => x.ToList().AddEmptyLine(x.Max(y => y.Count))).ToList();
                CreerDossiers();
                ChangeStatus("Enregistrement du fichier des fratries...");
                csvFratries.Enregistrer(Path.Combine(st, "Fratries.csv"));
                ChangeProgressBarCurrent(6, 6);
                Thread.Sleep(500);
                CreerDossiers(); // Acquis de conscience, juste au cas où
                ChangeProgressBarTotal(3, 6);
                ChangeProgressBarCurrent(0, _csvFichierEleves.Lignes.Count);
                ChangeStatus("Génération des fichiers CSV...");
                var csvClasses = new Dictionary<string, FichierCsv>();
                foreach (var d in _csvFichierEleves.Lignes.Select(x => x[_indices["DIV"]]).Distinct())
                {
                    var csv = new FichierCsv {Colonnes = _csvFichierEleves.Colonnes.ToList()};
                    csv.Colonnes.AddRange(new[] {"Adherent", "Famille", "Delegues", "Caution", "loc_adhe", "Loc_NON"});
                    for (var i = 1; i <= 16; i++)
                    {
                        csv.Colonnes.Add("L" + i.ToString().PadLeft(2, '0'));
                    }
                    csvClasses.Add(d, csv);
                }

                for (var i = 0; i < _csvFichierEleves.Lignes.Count; i++)
                {
                    var curl = _csvFichierEleves.Lignes[i].ToList();
                    try
                    {
                        var div = curl[_indices["DIV"]];

                        if (string.IsNullOrWhiteSpace(div) || string.IsNullOrWhiteSpace(curl[_indices["DIV SIECLE"]]))
                        {
                            csvAnomalie.Lignes.Add(curl);
                            continue;
                        }

                        curl.AddRange(new[] {"", "", ""}); // Adherent, Famille, Delegues (ne pas remplir)

                        if (_csvDivisionsExclues != null && _csvDivisionsExclues.Lignes.Any(x => x.Contains(div)))
                            continue;

                        var ligneDansFichDiv = _csvDivisions.Lignes.FirstOrDefault(x => x.Skip(4).Contains(div));
                        if (ligneDansFichDiv == null)
                        {
                                // Anomalie
                                csvDivAnom.Lignes.Add(new List<string> {curl[0], curl[1], div});
                            continue;
                        }

                        curl.AddRange(ligneDansFichDiv.GetRange(1, 3));

                        var lignesLivres = _csvFichierLivres.Lignes.Where(x => x[0] == ligneDansFichDiv[0]).ToArray();

                        foreach (var cli in curl.Skip(_indices["OPTION 1"]).Take(_indices["NB OPTIONS"]))
                        {
                            if (lignesLivres.All(x => x[1] != cli) && !string.IsNullOrWhiteSpace(cli) && cli != "NC")
                            {
                                if (_csvOptionsExclues == null ||
                                    !_csvOptionsExclues.Lignes.Any(
                                        y => (y[0] == "ALL" || y[0] == ligneDansFichDiv[0]) && y[1] == cli))
                                {
                                    // Anomalie
                                    csvOptAnom.Lignes.Add(new List<string> {curl[0], curl[1], div, cli});
                                }
                            }
                        }
                        _collivre1 = curl.Count;

                        curl.AddRange(
                            lignesLivres.Where(
                                x =>
                                    (x[1] == "STD" || curl.Skip(_indices["OPTION 1"]).Take(_indices["NB OPTIONS"]).Contains(x[1])) &&
                                    (_csvOptionsExclues == null || !_csvOptionsExclues.Lignes.Any(
                                        y => (y[0] == "ALL" || y[0] == ligneDansFichDiv[0]) && y[1] == x[1])))
                                .Select(x => x.Skip(2).Where(y => !string.IsNullOrWhiteSpace(y)))
                                .SelectMany(x => x));

                        csvClasses[div].Lignes.Add(curl);
                    }
                    catch
                    {
                        csvAnomalie.Lignes.Add(curl);
                    }

                    ChangeProgressBarCurrent(i + 1, _csvFichierEleves.Lignes.Count);
                }

                /*foreach (var kvp in csvClasses)
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
                }*/

                ChangeProgressBarTotal(4, 6);
                ChangeProgressBarCurrent(0, 3);
                ChangeStatus("Enregistrement des fichiers CSV de traitement...");
                Thread.Sleep(200);
                CreerDossiers(); // Acquis de conscience, juste au cas où
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
                    var iddivs = it.Value.Lignes[0][_indices["DIV SIECLE"]];
                    var iddiv = it.Value.Lignes[0][_indices["DIV"]];
                    it.Value.Enregistrer(Path.Combine(sd, iddivs + ".csv"));

                    var ficheVierge = it.Value.Clone();
                    ficheVierge.Lignes.Clear();
                    var l = ficheVierge.Colonnes.Select(x => ".").Take(_collivre1).ToList();
                    var ligneDansFichDiv = _csvDivisions.Lignes.FirstOrDefault(x => x.Skip(4).Contains(iddiv));
                    if (ligneDansFichDiv != null)
                    {
                        l.AddRange(_csvFichierLivres.Lignes.Where(x => x[0] == ligneDansFichDiv[0]).SelectMany(x => x.Skip(2)).Where(x => !string.IsNullOrWhiteSpace(x)).Distinct());
                        ficheVierge.Lignes.Add(l.ToSize(ficheVierge.Colonnes.Count).ToList());
                        ficheVierge.Enregistrer(Path.Combine(sd, iddivs + "-vierge.csv"));
                    }

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

        private int _collivre1 = -1;

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

        private void ChangeStatus(string stat)
        {
            if (lblStatus.InvokeRequired) lblStatus.Invoke((MethodInvoker) (() => lblStatus.Text = stat));
            else lblStatus.Text = stat;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "GestionFichiersEleves " + Assembly.GetExecutingAssembly().GetName().Version.ToString(3) + "\n" +
                "Copyright © Tom Niget (zdimension) 2016-2019\n\n" +
                "GestionFichiersEleves est un logiciel développé par Tom Niget (moi), à l'époque élève en classe de 2°6 du lycée " +
                "Guillaume Fichet de Bonneville, pour l'Association des Parents d'Élèves de Bonneville (APEB), dans le " +
                "cadre du cours ICN (Informatique et Création Numérique).\n\nEn cas de problème n'hésitez pas à me " +
                "contacter à l'adresse e-mail suivante :\ntom.niget@etu.univ-savoie.fr\n\n" +
                "Date de compilation : " + Assembly.GetExecutingAssembly().GetLinkerTime().ToString("dd/MM/yyyy HH:mm:ss"),
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

        private bool _eleveModif;
        private bool _livresModif;
        private bool _divModif;
        private bool _divExclModif;
        private bool _optExclModif;

        private void dgvEleves_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _eleveModif = true;
        }

        private void dgvLivres_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _livresModif = true;
        }

        private void dgvDivisions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _divModif = true;
        }

        private void dgvDivisionsExclues_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _divExclModif = true;
        }

        private void dgvOptionsExclues_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _optExclModif = true;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
           
            var verifs = new List<Tuple<bool, string, string, FichierCsv>>
            {
                Tuple.Create(_eleveModif, "élèves", fsFichierEleves.FileName, FichierCsv.FromDgv(dgvEleves)),
                Tuple.Create(_divExclModif, "divisions exclues", fsDivisionsExclues.FileName, FichierCsv.FromDgv(dgvDivisionsExclues)),
                Tuple.Create(_optExclModif, "options exclues", fsOptionsExclues.FileName, FichierCsv.FromDgv(dgvOptionsExclues)),
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

            if (_livresModif)
                if (MessageBox.Show(
                    "Le fichier des livres a été modifié à l'intérieur de " +
                    "GestionFichierEleves. Si vous fermez GestionFichierEleves," +
                    " toutes les modifications seront perdues. Voulez-vous vraiment quitter ?", "Attention",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                    keep = true;

            if (_divModif && !keep)
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
