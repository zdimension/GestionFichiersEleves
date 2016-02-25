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

using System.Windows.Forms;

namespace GestionFichiersEleves
{
    partial class FileSelector
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.Label();
            this.ofpFile = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AllowDrop = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnBrowse, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFile, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(506, 26);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileSelector_DragDrop);
            this.tableLayoutPanel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileSelector_DragEnter);
            // 
            // btnBrowse
            // 
            this.btnBrowse.AllowDrop = true;
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowse.Image = global::GestionFichiersEleves.Properties.Resources.folder_explorer;
            this.btnBrowse.Location = new System.Drawing.Point(394, 0);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(0);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(112, 26);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = " Parcourir";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            this.btnBrowse.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileSelector_DragDrop);
            this.btnBrowse.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileSelector_DragEnter);
            // 
            // txtFile
            // 
            this.txtFile.AutoEllipsis = true;
            this.txtFile.BackColor = System.Drawing.SystemColors.Window;
            this.txtFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFile.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtFile.Location = new System.Drawing.Point(1, 1);
            this.txtFile.Margin = new System.Windows.Forms.Padding(1);
            this.txtFile.Name = "txtFile";
            this.txtFile.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.txtFile.Size = new System.Drawing.Size(392, 24);
            this.txtFile.TabIndex = 2;
            this.txtFile.Text = "Glissez-déposez un fichier ou cliquez sur Parcourir";
            this.txtFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtFile.SizeChanged += new System.EventHandler(this.txtFile_SizeChanged);
            // 
            // ofpFile
            // 
            this.ofpFile.DefaultExt = "csv";
            this.ofpFile.Filter = "Classeur CSV (*.csv)|*.csv";
            this.ofpFile.Title = "Choisir un fichier";
            // 
            // FileSelector
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FileSelector";
            this.Size = new System.Drawing.Size(506, 26);
            this.Load += new System.EventHandler(this.FileSelector_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileSelector_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileSelector_DragEnter);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog ofpFile;
        private Label txtFile;
        private ToolTip toolTip1;
    }
}
