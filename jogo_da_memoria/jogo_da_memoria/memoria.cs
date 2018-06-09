using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace jogo_da_memoria
{
    public partial class memoria : Form
    {
        int cliques, movimentos, cartasEncontradas, tagIndex;

        Image[] img = new Image [9];

        List<string> lista = new List<string>();

        int[] tags = new int[2];

        public memoria()
        {
            InitializeComponent();
            Inicio();
        }

        public void Inicio() {

            foreach (PictureBox item in Controls.OfType<PictureBox>()) {

                tagIndex = int.Parse(String.Format("{0}", item.Tag));
                img[tagIndex] = item.Image;
                item.Image = Properties.Resources._6099a1f4051c9cd36ef874eade58da23;
                item.Enabled = true;
            }

            Posiçoes();
        }

            public void Posiçoes(){

                foreach (PictureBox item in Controls.OfType<PictureBox>()){
            
                    Random rdn = new Random();

                    int[] xP = { 49, 158, 267, 376, 485, 594 };
                    int[] yP = { 46, 128, 210 };


                repete:
                    var X = xP[rdn.Next(0, xP.Length)];
                    var Y = yP[rdn.Next(0, yP.Length)];

                    String Verificacao = X.ToString() + Y.ToString();

                    if (lista.Contains(Verificacao)) {


                        goto repete;

                    } else {

                        item.Location = new Point(X, Y);
                        lista.Add(Verificacao);
                    
               }                 
            }
        }

            private void ImagensClick_Click (object sender, EventArgs e) {

                bool parEncontrado = false;

                PictureBox pic = (PictureBox) sender;
                cliques++;
                tagIndex = int.Parse(String.Format("{0}", pic.Tag));
                pic.Image = img[tagIndex];
                pic.Refresh();

                if (cliques == 1) {

                    tags[0] = int.Parse(String.Format("{0}", pic.Tag));

                } 
                else if (cliques == 2) {

                    movimentos++;
                    lblJogadas.Text = "Jogadas: " + movimentos.ToString();
                    tags[1] = int.Parse(String.Format("{0}", pic.Tag));
                    parEncontrado = ChecagemPares();
                    Desvirar(parEncontrado);
                }
            }

            private bool ChecagemPares() {

                cliques = 0;

                if (tags[0] == tags[1]) {
                    return true; 
                } else{
                    return false;
              }
            }

            private void Desvirar(bool check) {

                Thread.Sleep(500); // O que vier abaixo irá demorar o tempo digitado em s


                foreach (PictureBox item in Controls.OfType<PictureBox>())
                {

                    if (int.Parse(String.Format("{0}", item.Tag)) == tags[0] ||
                        int.Parse(String.Format("{0}", item.Tag)) == tags[1]){

                            if (check == true) {

                                item.Enabled = false;
                                cartasEncontradas++;
                            
                            } else {

                                item.Image = Properties.Resources._6099a1f4051c9cd36ef874eade58da23;
                                item.Refresh();
                      } 
                    }
                }

                finalJogo();
            }

            private void finalJogo() {

                if (cartasEncontradas == (img.Length * 2)) {

                    MessageBox.Show("Parabens, Você concluiu o jogo! Você usou " + movimentos.ToString()
                        + " Jogadas");
                    DialogResult msn = MessageBox.Show("Deseja Continuar Jogando? ", "Caixa de Pergunta", MessageBoxButtons.YesNo);

                    if (msn == DialogResult.Yes) {

                        cliques = 0; movimentos = 0; cartasEncontradas = 0;
                        lista.Clear();
                        Inicio();

                    }
                    else if (msn == DialogResult.No) {

                        MessageBox.Show("Obrigado por Jogar, até a proxima :D");
                        Application.Exit();
                    
                    }

                }
            
            }

    }
}
