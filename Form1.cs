using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodigoDeHamming
{
    public partial class Form1 : Form
    {
        public byte[,] matrizGeradora = new byte[7, 4];
        public byte[,] matrizParidade = new byte[3,7];
        public byte[] vetorBinario = new byte[4];
        public byte[] vetorHaming = new byte[7];
        public byte[] vetorParidade = new byte[3];
        public byte[] vetorErro = new byte[7];
        public byte[] vetorCorrecao = new byte[7];

        public Form1()
        {

            InitializeComponent();


            // inicializa a matriz geradora
            matrizGeradora[0, 0] = 1; matrizGeradora[0, 1] = 1; matrizGeradora[0, 2] = 0; matrizGeradora[0, 3] = 1;
            matrizGeradora[1, 0] = 1; matrizGeradora[1, 1] = 0; matrizGeradora[1, 2] = 1; matrizGeradora[1, 3] = 1;
            matrizGeradora[2, 0] = 1; matrizGeradora[2, 1] = 0; matrizGeradora[2, 2] = 0; matrizGeradora[2, 3] = 0;
            matrizGeradora[3, 0] = 0; matrizGeradora[3, 1] = 1; matrizGeradora[3, 2] = 1; matrizGeradora[3, 3] = 1;
            matrizGeradora[4, 0] = 0; matrizGeradora[4, 1] = 1; matrizGeradora[4, 2] = 0; matrizGeradora[4, 3] = 0;
            matrizGeradora[5, 0] = 0; matrizGeradora[5, 1] = 0; matrizGeradora[5, 2] = 1; matrizGeradora[5, 3] = 0;
            matrizGeradora[6, 0] = 0; matrizGeradora[6, 1] = 0; matrizGeradora[6, 2] = 0; matrizGeradora[6, 3] = 1;


            // inicializa a matriz de paridade

            matrizParidade[0, 0] = 1; matrizParidade[0, 1] = 0; matrizParidade[0, 2] = 1; matrizParidade[0, 3] = 0; matrizParidade[0, 4] = 1; matrizParidade[0, 5] = 0; matrizParidade[0, 6] = 1;
            matrizParidade[1, 0] = 0; matrizParidade[1, 1] = 1; matrizParidade[1, 2] = 1; matrizParidade[1, 3] = 0; matrizParidade[1, 4] = 0; matrizParidade[1, 5] = 1; matrizParidade[1, 6] = 1;
            matrizParidade[2, 0] = 0; matrizParidade[2, 1] = 0; matrizParidade[2, 2] = 0; matrizParidade[2, 3] = 1; matrizParidade[2, 4] = 1; matrizParidade[2, 5] = 1; matrizParidade[2, 6] = 1;
            


        }

        private void btnGerarMatriz_Click_1(object sender, EventArgs e)
        {
            
        }

        public void GerarMatrizGeradora()
        {
            for (int i = 0; i < 7; i++)
            {
                string linha = "";

                for (int j = 0; j < 4; j++)
                {
                    linha += " " + matrizGeradora[i, j] + " ";
                }

                listBox1.Items.Add(linha);
            }
        }

        private void btnConverterBinario_Click(object sender, EventArgs e)
        {

            if(tbNumero.Text == "")
            {
                MessageBox.Show("Informe um valor válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int valor = Convert.ToInt32(tbNumero.Text);

            if (valor > 15 || valor < 0)
            {
                MessageBox.Show("O sistema só aceita números de no máximo 4 bits, ou seja de 0 a 15!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            converterBinario(Convert.ToInt32(tbNumero.Text));
            gerarMatrizes();
        }

        

        public void converterBinario( int numero)
        {
            for (int i = 0; i < 4; i++)
            {
                byte mod = Convert.ToByte(numero % 2);
                vetorBinario[i] = mod;
                numero = numero >> 1;
            }

            String valorConcatenado = vetorBinario[3] + "" + vetorBinario[2] + "" + vetorBinario[1] + "" + vetorBinario[0];
            MessageBox.Show("Número em binario:" + valorConcatenado ,"Informação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            tbBinario.Text = valorConcatenado.ToString();            

        }

        private void btnVerVetor_Click(object sender, EventArgs e)
        {
                        
        }

        public void verVetorBinario()
        {
            for (int i = 3; i >= 0; i--)
            {
                listBox2.Items.Add(vetorBinario[i]);
            }
        }
        private void btnGerarHamming_Click(object sender, EventArgs e)
        {
            
           
        }

        public void gerarHaming()
        {
            int posicaoVetor = 3;

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    vetorHaming[i] = Convert.ToByte((Convert.ToInt32(vetorHaming[i]) + matrizGeradora[i, j] * vetorBinario[posicaoVetor]) & 1);

                }
                posicaoVetor = posicaoVetor - 1;
            }
            for (int i = 0; i < vetorHaming.Length; i++)
            {
                listBox3.Items.Add(vetorHaming[i]);
                tbHaming.Text += vetorHaming[i];
            }

            
        }

        private void btnConverterBinario_MouseClick(object sender, MouseEventArgs e)
        {
            gerarMatrizes();           
            
        }

        private void btnGerarParidade_Click(object sender, EventArgs e)
        {
            
        }

        public void gerarParidade()
        {
            for (int i = 0; i < 3; i++)
            {
                string linha = "";

                for (int j = 0; j < 7; j++)
                {
                    linha += " " + matrizParidade[i, j]  + " ";
                }

                listBox4.Items.Add(linha);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        public void gerarVetorParidade()
        {
            int posicaoVetor = 6;

            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    vetorParidade[i] += (Convert.ToByte(matrizParidade[i, j] * vetorHaming[j]));

                }
                posicaoVetor = posicaoVetor - 1;
            }

            for (int i = 0; i < vetorParidade.Length; i++)
            {
                listBox5.Items.Add(vetorParidade[i] ); ///// %2
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAtualiza_Click(object sender, EventArgs e)
        {

            //limpar
            listBox3.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();

            for (int i = 0; i < vetorHaming.Length; i++)
            {
                vetorHaming[i] = 0;
            }

            for (int i = 0; i < vetorParidade.Length; i++)
            {
                vetorParidade[i] = 0;
            }

            if (tbHaming.Text.Length != 0)
            {
               var lista = new List<Int32>();
                var x = tbHaming.Text;
                for (int i = 0; i < x.Length; i++)
                {
                    Int32 num = 0;
                    if (Int32.TryParse(x.Substring(i, 1), out num))
                       lista.Add(num);
                    listBox3.Items.Add(lista[i]);
                    vetorHaming[i] = Convert.ToByte(lista[i]);
                }
                               
                gerarVetorParidade();
            }

            string soma = ((vetorParidade[2]) % 2).ToString() + ((vetorParidade[1]) % 2).ToString() + ((vetorParidade[0]) % 2).ToString();

           
            MessageBox.Show("O erro encontra-se no bit: " + Convert.ToInt32(soma, 2) , "Informação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            if (tbHaming.Text.Length != 0)
            {
                var lista = new List<Int32>();
                var x = tbHaming.Text;
                for (int i = 0; i < x.Length; i++)
                {
                    Int32 num = 0;
                    if (Int32.TryParse(x.Substring(i, 1), out num))
                        lista.Add(num);                    
                    vetorCorrecao[i] = Convert.ToByte(lista[i]);
                    
                }

               
                int bitAlterado = Convert.ToInt32(soma, 2);
                

                for ( int i = 0; i < x.Length; i++)
                {
                   if(vetorCorrecao[bitAlterado -1] == 0 )
                    {
                        vetorCorrecao[bitAlterado -1] = 1;
                    }
                    else
                    {
                        vetorCorrecao[bitAlterado -1] = 0;
                    }

                    
                }

                for (int i = 0; i < x.Length; i++)
                {
                    listBox6.Items.Add(vetorCorrecao[i]);
                }                                

            }


        }

        private void tbNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8))//&& !(e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
        }

        private void tbBinario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8))//&& !(e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
        }

        private void tbHaming_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && !(e.KeyChar == (char)8))//&& !(e.KeyChar == (char)44)
            {
                e.Handled = true;
            }
        }

        private void btnConverterBinario_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnConverterBinario_Enter(object sender, EventArgs e)
        {


        }

        private void btnConverterBinario_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public void gerarMatrizes()
        {
            if (tbNumero.Text == "")
            {

                return;
            }

            int valor = Convert.ToInt32(tbNumero.Text);
            if (valor > 15 || valor < 0)
            {

                return;
            }
            //limpa dados do vetor e das list box
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            tbHaming.Text = "";


            for (int i = 0; i < vetorHaming.Length; i++)
            {
                vetorHaming[i] = 0;
            }

            for (int i = 0; i < vetorParidade.Length; i++)
            {
                vetorParidade[i] = 0;
            }
            GerarMatrizGeradora();
            verVetorBinario();
            gerarHaming();
            gerarParidade();
            gerarVetorParidade();

        }

        private void tbHaming_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void tbHaming_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
