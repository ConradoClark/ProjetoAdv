namespace Visao
{
    partial class CadastroAdvogados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoAdv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maskCPF = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomeAdv = new System.Windows.Forms.TextBox();
            this.txtOAB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.maskRG = new System.Windows.Forms.MaskedTextBox();
            this.chkEstagiario = new System.Windows.Forms.CheckBox();
            this.advogadosGridView = new System.Windows.Forms.DataGridView();
            this.OAB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removerLinhaContextButton = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.txtNaturalidade = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.estadoCivil = new System.Windows.Forms.ComboBox();
            this.nacionalidade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.codigoBusca = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelarGrid = new System.Windows.Forms.Button();
            this.btnSalvarGrid = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.advogadosGridView)).BeginInit();
            this.menuGridView.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registro na OAB";
            // 
            // txtCodigoAdv
            // 
            this.txtCodigoAdv.Enabled = false;
            this.txtCodigoAdv.Location = new System.Drawing.Point(9, 52);
            this.txtCodigoAdv.Name = "txtCodigoAdv";
            this.txtCodigoAdv.Size = new System.Drawing.Size(72, 20);
            this.txtCodigoAdv.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "C.P.F";
            // 
            // maskCPF
            // 
            this.maskCPF.Location = new System.Drawing.Point(9, 92);
            this.maskCPF.Mask = "999.999.999-99";
            this.maskCPF.Name = "maskCPF";
            this.maskCPF.Size = new System.Drawing.Size(106, 20);
            this.maskCPF.TabIndex = 3;
            this.maskCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nome";
            // 
            // txtNomeAdv
            // 
            this.txtNomeAdv.Location = new System.Drawing.Point(10, 140);
            this.txtNomeAdv.Name = "txtNomeAdv";
            this.txtNomeAdv.Size = new System.Drawing.Size(442, 20);
            this.txtNomeAdv.TabIndex = 5;
            // 
            // txtOAB
            // 
            this.txtOAB.Location = new System.Drawing.Point(107, 52);
            this.txtOAB.MaxLength = 6;
            this.txtOAB.Name = "txtOAB";
            this.txtOAB.Size = new System.Drawing.Size(130, 20);
            this.txtOAB.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 182;
            this.label6.Text = "Código";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(129, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 183;
            this.label7.Text = "R.G";
            // 
            // maskRG
            // 
            this.maskRG.Location = new System.Drawing.Point(132, 92);
            this.maskRG.Mask = "999.999.999-99";
            this.maskRG.Name = "maskRG";
            this.maskRG.Size = new System.Drawing.Size(105, 20);
            this.maskRG.TabIndex = 184;
            this.maskRG.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // chkEstagiario
            // 
            this.chkEstagiario.AutoSize = true;
            this.chkEstagiario.Location = new System.Drawing.Point(253, 54);
            this.chkEstagiario.Name = "chkEstagiario";
            this.chkEstagiario.Size = new System.Drawing.Size(84, 17);
            this.chkEstagiario.TabIndex = 187;
            this.chkEstagiario.Text = "Estagiário(a)";
            this.chkEstagiario.UseVisualStyleBackColor = true;
            this.chkEstagiario.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // advogadosGridView
            // 
            this.advogadosGridView.AllowUserToAddRows = false;
            this.advogadosGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advogadosGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OAB,
            this.CPF,
            this.Nome,
            this.Quantidade});
            this.advogadosGridView.ContextMenuStrip = this.menuGridView;
            this.advogadosGridView.Location = new System.Drawing.Point(12, 50);
            this.advogadosGridView.Name = "advogadosGridView";
            this.advogadosGridView.Size = new System.Drawing.Size(600, 171);
            this.advogadosGridView.TabIndex = 188;
            // 
            // OAB
            // 
            this.OAB.DataPropertyName = "Oab";
            this.OAB.HeaderText = "Registro OAB";
            this.OAB.Name = "OAB";
            // 
            // CPF
            // 
            this.CPF.DataPropertyName = "Cpf";
            this.CPF.HeaderText = "C.P.F";
            this.CPF.Name = "CPF";
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.MinimumWidth = 200;
            this.Nome.Name = "Nome";
            // 
            // Quantidade
            // 
            this.Quantidade.DataPropertyName = "QuantidadeProcessos";
            this.Quantidade.HeaderText = "Quantidade de Processos";
            this.Quantidade.MinimumWidth = 94;
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.Width = 94;
            // 
            // menuGridView
            // 
            this.menuGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removerLinhaContextButton});
            this.menuGridView.Name = "menuGridView";
            this.menuGridView.Size = new System.Drawing.Size(154, 26);
            // 
            // removerLinhaContextButton
            // 
            this.removerLinhaContextButton.Name = "removerLinhaContextButton";
            this.removerLinhaContextButton.Size = new System.Drawing.Size(153, 22);
            this.removerLinhaContextButton.Text = "&Remover Linha";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbSexo);
            this.groupBox1.Controls.Add(this.txtNaturalidade);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.estadoCivil);
            this.groupBox1.Controls.Add(this.nacionalidade);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnSalvar);
            this.groupBox1.Controls.Add(this.chkEstagiario);
            this.groupBox1.Controls.Add(this.maskRG);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtOAB);
            this.groupBox1.Controls.Add(this.txtNomeAdv);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.maskCPF);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCodigoAdv);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(618, 222);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro de Advogados";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(506, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 203;
            this.label11.Text = "Sexo";
            // 
            // cmbSexo
            // 
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Location = new System.Drawing.Point(509, 188);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(46, 21);
            this.cmbSexo.TabIndex = 202;
            // 
            // txtNaturalidade
            // 
            this.txtNaturalidade.Location = new System.Drawing.Point(140, 189);
            this.txtNaturalidade.Name = "txtNaturalidade";
            this.txtNaturalidade.Size = new System.Drawing.Size(167, 20);
            this.txtNaturalidade.TabIndex = 201;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(137, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 200;
            this.label10.Text = "Naturalidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 198;
            this.label5.Text = "Estado Civil";
            // 
            // estadoCivil
            // 
            this.estadoCivil.FormattingEnabled = true;
            this.estadoCivil.Location = new System.Drawing.Point(9, 189);
            this.estadoCivil.Name = "estadoCivil";
            this.estadoCivil.Size = new System.Drawing.Size(121, 21);
            this.estadoCivil.TabIndex = 199;
            // 
            // nacionalidade
            // 
            this.nacionalidade.Location = new System.Drawing.Point(327, 189);
            this.nacionalidade.Name = "nacionalidade";
            this.nacionalidade.Size = new System.Drawing.Size(167, 20);
            this.nacionalidade.TabIndex = 197;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 196;
            this.label4.Text = "Nacionalidade";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Visao.Properties.Resources.canc24;
            this.btnCancelar.Location = new System.Drawing.Point(577, 19);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(35, 28);
            this.btnCancelar.TabIndex = 195;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::Visao.Properties.Resources.conf24;
            this.btnSalvar.Location = new System.Drawing.Point(536, 19);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(35, 28);
            this.btnSalvar.TabIndex = 192;
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnRemover
            // 
            this.btnRemover.Image = global::Visao.Properties.Resources.SairPrograma24x24;
            this.btnRemover.Location = new System.Drawing.Point(339, 9);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(35, 28);
            this.btnRemover.TabIndex = 194;
            this.btnRemover.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Image = global::Visao.Properties.Resources.limpar;
            this.btnLimpar.Location = new System.Drawing.Point(380, 9);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(35, 28);
            this.btnLimpar.TabIndex = 193;
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::Visao.Properties.Resources.search_24x24;
            this.btnBuscar.Location = new System.Drawing.Point(257, 9);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(35, 28);
            this.btnBuscar.TabIndex = 196;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 15);
            this.label8.TabIndex = 195;
            this.label8.Text = "Código do Advogado";
            // 
            // codigoBusca
            // 
            this.codigoBusca.Location = new System.Drawing.Point(144, 13);
            this.codigoBusca.Name = "codigoBusca";
            this.codigoBusca.Size = new System.Drawing.Size(100, 20);
            this.codigoBusca.TabIndex = 194;
            // 
            // btnSair
            // 
            this.btnSair.Image = global::Visao.Properties.Resources.sair24;
            this.btnSair.Location = new System.Drawing.Point(589, 9);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(35, 28);
            this.btnSair.TabIndex = 197;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox2.Controls.Add(this.btnCancelarGrid);
            this.groupBox2.Controls.Add(this.btnSalvarGrid);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.advogadosGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(618, 233);
            this.groupBox2.TabIndex = 198;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de Advogados";
            // 
            // btnCancelarGrid
            // 
            this.btnCancelarGrid.Image = global::Visao.Properties.Resources.canc24;
            this.btnCancelarGrid.Location = new System.Drawing.Point(577, 16);
            this.btnCancelarGrid.Name = "btnCancelarGrid";
            this.btnCancelarGrid.Size = new System.Drawing.Size(35, 28);
            this.btnCancelarGrid.TabIndex = 196;
            this.btnCancelarGrid.UseVisualStyleBackColor = true;
            // 
            // btnSalvarGrid
            // 
            this.btnSalvarGrid.Image = global::Visao.Properties.Resources.conf24;
            this.btnSalvarGrid.Location = new System.Drawing.Point(536, 16);
            this.btnSalvarGrid.Name = "btnSalvarGrid";
            this.btnSalvarGrid.Size = new System.Drawing.Size(35, 28);
            this.btnSalvarGrid.TabIndex = 193;
            this.btnSalvarGrid.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(296, 13);
            this.label9.TabIndex = 189;
            this.label9.Text = "Clique nos membros da tabela para Editar no formulário acima";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Image = global::Visao.Properties.Resources.add24;
            this.btnAdicionar.Location = new System.Drawing.Point(298, 9);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(35, 28);
            this.btnAdicionar.TabIndex = 200;
            this.btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // CadastroAdvogados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(644, 514);
            this.ControlBox = false;
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.codigoBusca);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CadastroAdvogados";
            this.Text = "CadastroAdvogados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CadastroAdvogados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advogadosGridView)).EndInit();
            this.menuGridView.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoAdv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskCPF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomeAdv;
        private System.Windows.Forms.TextBox txtOAB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskRG;
        private System.Windows.Forms.CheckBox chkEstagiario;
        private System.Windows.Forms.DataGridView advogadosGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox codigoBusca;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSalvarGrid;
        private System.Windows.Forms.Button btnCancelarGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn OAB;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.TextBox nacionalidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox estadoCivil;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.ContextMenuStrip menuGridView;
        private System.Windows.Forms.ToolStripMenuItem removerLinhaContextButton;
        private System.Windows.Forms.TextBox txtNaturalidade;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbSexo;

    }
}