using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GestionFichiersEleves
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbxCurrent = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbxTotal = new System.Windows.Forms.ProgressBar();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.bwMain = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvEleves = new GestionFichiersEleves.DataGridViewEx();
            this.dgvLivres = new GestionFichiersEleves.DataGridViewEx();
            this.dgvOptionsExclues = new GestionFichiersEleves.DataGridViewEx();
            this.dgvDivisionsExclues = new GestionFichiersEleves.DataGridViewEx();
            this.dgvDivisions = new GestionFichiersEleves.DataGridViewEx();
            this.fsFichierLivres = new GestionFichiersEleves.FileSelector();
            this.fsDivisions = new GestionFichiersEleves.FileSelector();
            this.fsDivisionsExclues = new GestionFichiersEleves.FileSelector();
            this.fsOptionsExclues = new GestionFichiersEleves.FileSelector();
            this.fsFichierEleves = new GestionFichiersEleves.FileSelector();
            this.pnlTop.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEleves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOptionsExclues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDivisionsExclues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDivisions)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.tableLayoutPanel2);
            this.pnlTop.Controls.Add(this.btnAbout);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(934, 166);
            this.pnlTop.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.24336F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.75664F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.43835F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.56165F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(934, 136);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.fsFichierLivres, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.fsDivisions, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.fsDivisionsExclues, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.fsOptionsExclues, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.fsFichierEleves, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(650, 130);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 26);
            this.label9.TabIndex = 8;
            this.label9.Text = "Options exclues :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "Divisions exclues :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Divisions :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fichier livres :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fichier élèves :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(659, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 130);
            this.panel1.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Image = global::GestionFichiersEleves.Properties.Resources.DataArrived96;
            this.btnStart.Location = new System.Drawing.Point(0, 0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(272, 130);
            this.btnStart.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnStart, "Démarrer la génération des fichiers CSV");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbout.Image = global::GestionFichiersEleves.Properties.Resources.information;
            this.btnAbout.Location = new System.Drawing.Point(0, 0);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(934, 30);
            this.btnAbout.TabIndex = 2;
            this.btnAbout.Text = "  À propos de GestionFichiersEleves";
            this.btnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.label4);
            this.pnlBottom.Controls.Add(this.label2);
            this.pnlBottom.Controls.Add(this.pbxCurrent);
            this.pnlBottom.Controls.Add(this.lblStatus);
            this.pnlBottom.Controls.Add(this.pbxTotal);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 511);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(8);
            this.pnlBottom.Size = new System.Drawing.Size(934, 80);
            this.pnlBottom.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Progression totale :";
            this.label4.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Opération actuelle :";
            this.label2.Visible = false;
            // 
            // pbxCurrent
            // 
            this.pbxCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxCurrent.Location = new System.Drawing.Point(131, 32);
            this.pbxCurrent.Name = "pbxCurrent";
            this.pbxCurrent.Size = new System.Drawing.Size(794, 21);
            this.pbxCurrent.TabIndex = 2;
            this.pbxCurrent.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(28, 15);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Prêt";
            // 
            // pbxTotal
            // 
            this.pbxTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxTotal.Location = new System.Drawing.Point(131, 59);
            this.pbxTotal.Name = "pbxTotal";
            this.pbxTotal.Size = new System.Drawing.Size(794, 12);
            this.pbxTotal.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbxTotal.TabIndex = 0;
            this.pbxTotal.Visible = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitContainer1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 166);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(934, 345);
            this.pnlMain.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel4);
            this.splitContainer1.Size = new System.Drawing.Size(934, 345);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel9, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(930, 168);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(930, 168);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.dgvOptionsExclues, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(623, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(304, 162);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.MinimumSize = new System.Drawing.Size(0, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(298, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Options exclues";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bwMain
            // 
            this.bwMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwMain_DoWork);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.dgvDivisionsExclues, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(313, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(304, 162);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.MinimumSize = new System.Drawing.Size(0, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(298, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Divisions exclues";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.dgvDivisions, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(304, 162);
            this.tableLayoutPanel7.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.MinimumSize = new System.Drawing.Size(0, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(298, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "Divisions";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.dgvEleves, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(459, 162);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.MinimumSize = new System.Drawing.Size(0, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(453, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "Élèves";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.dgvLivres, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(468, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(459, 162);
            this.tableLayoutPanel9.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.MinimumSize = new System.Drawing.Size(0, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(453, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "Livres";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvEleves
            // 
            this.dgvEleves.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEleves.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvEleves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEleves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEleves.Location = new System.Drawing.Point(0, 20);
            this.dgvEleves.Margin = new System.Windows.Forms.Padding(0);
            this.dgvEleves.Name = "dgvEleves";
            this.dgvEleves.Size = new System.Drawing.Size(459, 142);
            this.dgvEleves.TabIndex = 0;
            this.dgvEleves.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEleves_CellClick);
            this.dgvEleves.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEleves_CellValueChanged);
            // 
            // dgvLivres
            // 
            this.dgvLivres.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLivres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLivres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLivres.Location = new System.Drawing.Point(0, 20);
            this.dgvLivres.Margin = new System.Windows.Forms.Padding(0);
            this.dgvLivres.Name = "dgvLivres";
            this.dgvLivres.Size = new System.Drawing.Size(459, 142);
            this.dgvLivres.TabIndex = 1;
            this.dgvLivres.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLivres_CellValueChanged);
            // 
            // dgvOptionsExclues
            // 
            this.dgvOptionsExclues.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvOptionsExclues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOptionsExclues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOptionsExclues.Location = new System.Drawing.Point(0, 20);
            this.dgvOptionsExclues.Margin = new System.Windows.Forms.Padding(0);
            this.dgvOptionsExclues.Name = "dgvOptionsExclues";
            this.dgvOptionsExclues.Size = new System.Drawing.Size(304, 142);
            this.dgvOptionsExclues.TabIndex = 3;
            this.dgvOptionsExclues.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOptionsExclues_CellValueChanged);
            // 
            // dgvDivisionsExclues
            // 
            this.dgvDivisionsExclues.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDivisionsExclues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDivisionsExclues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDivisionsExclues.Location = new System.Drawing.Point(0, 20);
            this.dgvDivisionsExclues.Margin = new System.Windows.Forms.Padding(0);
            this.dgvDivisionsExclues.Name = "dgvDivisionsExclues";
            this.dgvDivisionsExclues.Size = new System.Drawing.Size(304, 142);
            this.dgvDivisionsExclues.TabIndex = 2;
            this.dgvDivisionsExclues.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDivisionsExclues_CellValueChanged);
            // 
            // dgvDivisions
            // 
            this.dgvDivisions.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDivisions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDivisions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDivisions.Location = new System.Drawing.Point(0, 20);
            this.dgvDivisions.Margin = new System.Windows.Forms.Padding(0);
            this.dgvDivisions.Name = "dgvDivisions";
            this.dgvDivisions.Size = new System.Drawing.Size(304, 142);
            this.dgvDivisions.TabIndex = 1;
            this.dgvDivisions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDivisions_CellValueChanged);
            // 
            // fsFichierLivres
            // 
            this.fsFichierLivres.AllowDrop = true;
            this.fsFichierLivres.BackColor = System.Drawing.SystemColors.Control;
            this.fsFichierLivres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsFichierLivres.FileName = "Glissez-déposez un fichier ou cliquez sur Parcourir";
            this.fsFichierLivres.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fsFichierLivres.Location = new System.Drawing.Point(107, 26);
            this.fsFichierLivres.Margin = new System.Windows.Forms.Padding(0);
            this.fsFichierLivres.Name = "fsFichierLivres";
            this.fsFichierLivres.Size = new System.Drawing.Size(543, 26);
            this.fsFichierLivres.TabIndex = 9;
            this.fsFichierLivres.SelectedFileChanged += new System.EventHandler(this.fsFichierLivres_SelectedFileChanged);
            // 
            // fsDivisions
            // 
            this.fsDivisions.AllowDrop = true;
            this.fsDivisions.BackColor = System.Drawing.SystemColors.Control;
            this.fsDivisions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsDivisions.FileName = "Glissez-déposez un fichier ou cliquez sur Parcourir";
            this.fsDivisions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fsDivisions.Location = new System.Drawing.Point(107, 52);
            this.fsDivisions.Margin = new System.Windows.Forms.Padding(0);
            this.fsDivisions.Name = "fsDivisions";
            this.fsDivisions.Size = new System.Drawing.Size(543, 26);
            this.fsDivisions.TabIndex = 10;
            this.fsDivisions.SelectedFileChanged += new System.EventHandler(this.fsDivisions_SelectedFileChanged);
            // 
            // fsDivisionsExclues
            // 
            this.fsDivisionsExclues.AllowDrop = true;
            this.fsDivisionsExclues.BackColor = System.Drawing.SystemColors.Control;
            this.fsDivisionsExclues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsDivisionsExclues.FileName = "Glissez-déposez un fichier ou cliquez sur Parcourir";
            this.fsDivisionsExclues.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fsDivisionsExclues.Location = new System.Drawing.Point(107, 78);
            this.fsDivisionsExclues.Margin = new System.Windows.Forms.Padding(0);
            this.fsDivisionsExclues.Name = "fsDivisionsExclues";
            this.fsDivisionsExclues.Size = new System.Drawing.Size(543, 26);
            this.fsDivisionsExclues.TabIndex = 11;
            this.fsDivisionsExclues.SelectedFileChanged += new System.EventHandler(this.fsDivisionsExclues_SelectedFileChanged);
            // 
            // fsOptionsExclues
            // 
            this.fsOptionsExclues.AllowDrop = true;
            this.fsOptionsExclues.BackColor = System.Drawing.SystemColors.Control;
            this.fsOptionsExclues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsOptionsExclues.FileName = "Glissez-déposez un fichier ou cliquez sur Parcourir";
            this.fsOptionsExclues.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fsOptionsExclues.Location = new System.Drawing.Point(107, 104);
            this.fsOptionsExclues.Margin = new System.Windows.Forms.Padding(0);
            this.fsOptionsExclues.Name = "fsOptionsExclues";
            this.fsOptionsExclues.Size = new System.Drawing.Size(543, 26);
            this.fsOptionsExclues.TabIndex = 12;
            this.fsOptionsExclues.SelectedFileChanged += new System.EventHandler(this.fsOptionsExclues_SelectedFileChanged);
            // 
            // fsFichierEleves
            // 
            this.fsFichierEleves.AllowDrop = true;
            this.fsFichierEleves.BackColor = System.Drawing.SystemColors.Control;
            this.fsFichierEleves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fsFichierEleves.FileName = "Glissez-déposez un fichier ou cliquez sur Parcourir";
            this.fsFichierEleves.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fsFichierEleves.Location = new System.Drawing.Point(107, 0);
            this.fsFichierEleves.Margin = new System.Windows.Forms.Padding(0);
            this.fsFichierEleves.Name = "fsFichierEleves";
            this.fsFichierEleves.Size = new System.Drawing.Size(543, 26);
            this.fsFichierEleves.TabIndex = 13;
            this.fsFichierEleves.SelectedFileChanged += new System.EventHandler(this.fsFichierEleves_SelectedFileChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 591);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(760, 515);
            this.Name = "MainWindow";
            this.Text = "GestionFichiersEleves";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.pnlTop.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEleves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLivres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOptionsExclues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDivisionsExclues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDivisions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlTop;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel pnlBottom;
        private Panel pnlMain;
        private Label label9;
        private Label label7;
        private Label label5;
        private Label label3;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private FileSelector fsFichierLivres;
        private FileSelector fsDivisions;
        private FileSelector fsDivisionsExclues;
        private FileSelector fsOptionsExclues;
        private FileSelector fsFichierEleves;
        private Panel panel1;
        private Button btnStart;
        private ProgressBar pbxTotal;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridViewEx dgvEleves;
        private DataGridViewEx dgvLivres;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel4;
        private DataGridViewEx dgvOptionsExclues;
        private DataGridViewEx dgvDivisionsExclues;
        private DataGridViewEx dgvDivisions;
        private BackgroundWorker bwMain;
        private ProgressBar pbxCurrent;
        private Label lblStatus;
        private ToolTip toolTip1;
        private Button btnAbout;
        private Label label4;
        private Label label2;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label6;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label11;
        private TableLayoutPanel tableLayoutPanel9;
        private Label label12;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label8;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label10;
    }
}

