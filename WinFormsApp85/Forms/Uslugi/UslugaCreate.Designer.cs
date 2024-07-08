
namespace WinFormsApp85.Forms.Uslugi
{
    partial class UslugaCreate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAnuluj = new System.Windows.Forms.Button();
            this.buttonZapisz = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxWykonawca = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCenaNetto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPodatekVat8 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPodatekVat22 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxZyskBrutto8 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxZyskBrutto22 = new System.Windows.Forms.TextBox();
            this.comboBoxRodzajUslugi = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(37, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Księgowanie nowej usługi";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.buttonAnuluj);
            this.panel2.Controls.Add(this.buttonZapisz);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 573);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(841, 100);
            this.panel2.TabIndex = 0;
            // 
            // buttonAnuluj
            // 
            this.buttonAnuluj.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAnuluj.Location = new System.Drawing.Point(575, 25);
            this.buttonAnuluj.Name = "buttonAnuluj";
            this.buttonAnuluj.Size = new System.Drawing.Size(180, 50);
            this.buttonAnuluj.TabIndex = 0;
            this.buttonAnuluj.Text = "Anuluj";
            this.buttonAnuluj.UseVisualStyleBackColor = true;
            this.buttonAnuluj.Click += new System.EventHandler(this.buttonAnuluj_Click);
            // 
            // buttonZapisz
            // 
            this.buttonZapisz.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonZapisz.Location = new System.Drawing.Point(377, 25);
            this.buttonZapisz.Name = "buttonZapisz";
            this.buttonZapisz.Size = new System.Drawing.Size(180, 50);
            this.buttonZapisz.TabIndex = 0;
            this.buttonZapisz.Text = "Zapisz";
            this.buttonZapisz.UseVisualStyleBackColor = true;
            this.buttonZapisz.Click += new System.EventHandler(this.buttonZapisz_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rodzaj usługi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "Wykonawca";
            // 
            // textBoxWykonawca
            // 
            this.textBoxWykonawca.Location = new System.Drawing.Point(286, 211);
            this.textBoxWykonawca.Margin = new System.Windows.Forms.Padding(8);
            this.textBoxWykonawca.Name = "textBoxWykonawca";
            this.textBoxWykonawca.Size = new System.Drawing.Size(469, 35);
            this.textBoxWykonawca.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 30);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cena netto";
            // 
            // textBoxCenaNetto
            // 
            this.textBoxCenaNetto.Location = new System.Drawing.Point(286, 262);
            this.textBoxCenaNetto.Margin = new System.Windows.Forms.Padding(8);
            this.textBoxCenaNetto.Name = "textBoxCenaNetto";
            this.textBoxCenaNetto.Size = new System.Drawing.Size(469, 35);
            this.textBoxCenaNetto.TabIndex = 2;
            this.textBoxCenaNetto.TextChanged += new System.EventHandler(this.textBoxCenaNetto_TextChanged);
            this.textBoxCenaNetto.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxCenaNetto_MouseDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "Podatek Vat 8";
            // 
            // textBoxPodatekVat8
            // 
            this.textBoxPodatekVat8.Location = new System.Drawing.Point(286, 313);
            this.textBoxPodatekVat8.Margin = new System.Windows.Forms.Padding(8);
            this.textBoxPodatekVat8.Name = "textBoxPodatekVat8";
            this.textBoxPodatekVat8.Size = new System.Drawing.Size(469, 35);
            this.textBoxPodatekVat8.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = "Podatek Vat 22";
            // 
            // textBoxPodatekVat22
            // 
            this.textBoxPodatekVat22.Location = new System.Drawing.Point(286, 364);
            this.textBoxPodatekVat22.Margin = new System.Windows.Forms.Padding(8);
            this.textBoxPodatekVat22.Name = "textBoxPodatekVat22";
            this.textBoxPodatekVat22.Size = new System.Drawing.Size(469, 35);
            this.textBoxPodatekVat22.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 415);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 30);
            this.label7.TabIndex = 1;
            this.label7.Text = "Zysk brutto 8";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxZyskBrutto8
            // 
            this.textBoxZyskBrutto8.Location = new System.Drawing.Point(286, 415);
            this.textBoxZyskBrutto8.Margin = new System.Windows.Forms.Padding(8);
            this.textBoxZyskBrutto8.Name = "textBoxZyskBrutto8";
            this.textBoxZyskBrutto8.Size = new System.Drawing.Size(469, 35);
            this.textBoxZyskBrutto8.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 466);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 30);
            this.label8.TabIndex = 1;
            this.label8.Text = "Zysk brutto 22";
            // 
            // textBoxZyskBrutto22
            // 
            this.textBoxZyskBrutto22.Location = new System.Drawing.Point(286, 466);
            this.textBoxZyskBrutto22.Margin = new System.Windows.Forms.Padding(8);
            this.textBoxZyskBrutto22.Name = "textBoxZyskBrutto22";
            this.textBoxZyskBrutto22.Size = new System.Drawing.Size(469, 35);
            this.textBoxZyskBrutto22.TabIndex = 2;
            // 
            // comboBoxRodzajUslugi
            // 
            this.comboBoxRodzajUslugi.FormattingEnabled = true;
            this.comboBoxRodzajUslugi.Location = new System.Drawing.Point(286, 156);
            this.comboBoxRodzajUslugi.Name = "comboBoxRodzajUslugi";
            this.comboBoxRodzajUslugi.Size = new System.Drawing.Size(469, 38);
            this.comboBoxRodzajUslugi.TabIndex = 3;
            this.comboBoxRodzajUslugi.SelectedIndexChanged += new System.EventHandler(this.comboBoxRodzajUslugi_SelectedIndexChanged);
            // 
            // UslugaCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 673);
            this.Controls.Add(this.comboBoxRodzajUslugi);
            this.Controls.Add(this.textBoxZyskBrutto22);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxZyskBrutto8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxPodatekVat22);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPodatekVat8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxCenaNetto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxWykonawca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UslugaCreate";
            this.Text = "Księgowanie nowej usługi";
            this.Load += new System.EventHandler(this.UslugaCreate_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAnuluj;
        private System.Windows.Forms.Button buttonZapisz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxWykonawca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCenaNetto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPodatekVat8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPodatekVat22;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxZyskBrutto8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxZyskBrutto22;
        private System.Windows.Forms.ComboBox comboBoxRodzajUslugi;
    }
}