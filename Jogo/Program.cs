using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace Jogo
{
    class Program
    {
        //tx e ty Jogador
        static float txJog = 0.0f;
        static float tyJog = -1.0f;

        //tx e ty Tiro
        static float txTiro = -37.0f;
        static float tyTiro = 0.0f;

        const float PI = 38.5f;

        //Desenha a cenario
        static void cenario()
        {
            //fundo
            Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
            Gl.glBegin(Gl.GL_QUADS);

            //Azul Claro
            Gl.glColor3f(0.117647f, 0.564706f, 1);
            Gl.glVertex2f(0.0f, 0.0f);

            //Azul Escuro
            Gl.glColor3f(0.0980392f, 0.0980392f, 0.439216f);
            Gl.glVertex2f(0.0f, 50.0f);

            //Azul Escuro
            Gl.glColor3f(0.0980392f, 0.0980392f, 0.439216f);
            Gl.glVertex2f(50.0f, 50.0f);

            //Azul Claro
            Gl.glColor3f(0.117647f, 0.564706f, 1);
            Gl.glVertex2f(50.0f, 0.0f);
            Gl.glEnd();
            //Fim fundo

            //Terra
            Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
            Gl.glBegin(Gl.GL_QUADS);
            
            //Escuro
            Gl.glColor3f(0.823529f, 0.411765f, 0.117647f);
            Gl.glVertex2f(0.0f, 0.0f);
            //clara
            Gl.glColor3f(0.803922f, 0.521569f, 0.247059f);
            Gl.glVertex2f(0.0f, 2.5f);
            //clara
            Gl.glColor3f(0.803922f, 0.521569f, 0.247059f);
            Gl.glVertex2f(50.0f, 2.5f);
            //Escuro
            Gl.glColor3f(0.823529f, 0.411765f, 0.117647f);
            Gl.glVertex2f(50.0f, 0.0f);
            Gl.glEnd();
            //Fim terra

            //Gramado
            Gl.glColor3f(0.133333f, 0.545098f, 0.133333f);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(0.0f, 2.0f);
            Gl.glVertex2f(0.0f, 2.5f);
            Gl.glVertex2f(50.0f, 2.5f);
            Gl.glVertex2f(50.0f, 2.0f);
            Gl.glEnd();
            //Fim gramado
        }

        //Desenho Jogador
        static void Jogador()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(txJog, tyJog, 0);
            Gl.glColor3f(0.0f, 0.0f, 205f);
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(37.0f, 3.5f);
            Gl.glVertex2f(37.0f, 5.0f);
            Gl.glVertex2f(40.0f, 5.0f);
            Gl.glVertex2f(40.0f, 3.5f);
            Gl.glEnd();

            Gl.glPopMatrix();
        }

        //Desenho Tiro
        static void Bomba()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(txTiro, tyTiro, 0);
            Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
            //Gl.glBegin(Gl.GL_QUADS);

            //Gl.glEnd();
            //Gl.glBegin(Gl.GL_QUADS);

            //Gl.glColor3f(0.333333f, 0.333333f, 0.333333f);
            //Gl.glVertex2f(37.0f, 11.5f);

            //Gl.glColor3f(0.0f, 0.0f, 0.0f);
            //Gl.glVertex2f(37.0f, 13.0f);

            //Gl.glColor3f(0.0f, 0.0f, 0.0f);
            //Gl.glVertex2f(40.0f, 13.0f);

            //Gl.glColor3f(0.333333f, 0.333333f, 0.333333f);
            //Gl.glVertex2f(40.0f, 11.5f);

            float raio, x, y, pontos;
            raio = 1.0f;
            pontos = (2 * PI) / 100;

            Gl.glColor3f(0.0f, 0.0f, 0.0f);
            Gl.glLineWidth(5);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex2f(37.0f, 13.0f);
            for (float angulo = 0.0f; angulo <= PI; angulo += pontos)
            {
                x = (float)(raio * Math.Cos(angulo) + 37.0f);
                y = (float)(raio * Math.Sin(angulo) + 13.0f);
                Gl.glVertex2f(x, y);
            }

            Gl.glEnd();

            Gl.glPopMatrix();
        }

        static void ColisaoJogador()
        {
            if (txJog <= -37.0f) { txJog = -37.0f; }
                Glut.glutPostRedisplay();
            if (txJog >= 6.0f) { txJog = 6.0f; }
                Glut.glutPostRedisplay();
        }

        static void ColisaoTiro()
        {
            if ( ((tyTiro * -1) >= 7.5f) && ( (txTiro == txJog) || (txTiro == txJog + 1) || (txTiro == txJog - 1) || (txTiro == txJog + 2) || (txTiro == txJog - 2) ) )
            {
                tyTiro = -7.5f;
                txJog = txTiro;
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            }
            else
            {
                if (tyTiro <= -12.0f) {

                    Random randNum = new Random();
                    txTiro = randNum.Next(-37, 6);

                    tyTiro = 0.0f;

                }
            }
            Glut.glutPostRedisplay();
        }


        static void Atirar()
        {

            tyTiro -= 0.03f;

        }

        static void DesenhaJogador()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            cenario();

            Bomba();
            Atirar();
            ColisaoTiro();

            Jogador();
            ColisaoJogador();

            Glut.glutSwapBuffers();
        }

        //Funcoes do teclado para mover jogador 
        static void Mover(int key, int x, int y)
        {
            if (key == Glut.GLUT_KEY_LEFT) { txJog -= 1.0f; }
            if (key == Glut.GLUT_KEY_RIGHT) { txJog += 1.0f; }
        }

        static void Inicializa()
        {
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0f, 46.0f, 0.0f, 13.0f);
            // Define a cor de fundo da janela de visualização como preta
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }


        static void Main(string[] args)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(800, 400);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("Sobrevivendo");
            Inicializa();
            Glut.glutDisplayFunc(DesenhaJogador);
            Glut.glutSpecialFunc(Mover);
            Glut.glutMainLoop();
        }
    }
}
