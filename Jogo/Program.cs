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
        static int sinal = 0;
        static float tx = 0.0f;

        //Desenha a pista
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

            //Gramado
            Gl.glColor3f(0.133333f, 0.545098f, 0.133333f);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(0.0f, 2.0f);
            Gl.glVertex2f(0.0f, 2.5f);
            Gl.glVertex2f(50.0f, 2.5f);
            Gl.glVertex2f(50.0f, 2.0f);
            Gl.glEnd();


        }

        //Desenho Jogador
        static void Jogador()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(tx, -1, 0);
            Gl.glColor3f(0.0f, 0.0f, 205f);
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(37f, 3.5f);
            Gl.glVertex2f(37f, 5.0f);
            Gl.glVertex2f(40f, 5.0f);
            Gl.glVertex2f(40f, 3.5f);
            Gl.glEnd();

            Gl.glPopMatrix();
        }

        //Desenho Tiro
        static void tiro()
        {
            Gl.glPolygonMode(Gl.GL_BACK, Gl.GL_FILL);
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glEnd();
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glColor3f(0.333333f, 0.333333f, 0.333333f);
            Gl.glVertex2f(35f, 10f);

            Gl.glColor3f(0.0f, 0.0f, 0.0f);
            Gl.glVertex2f(35f, 13f);

            Gl.glColor3f(0.0f, 0.0f, 0.0f);
            Gl.glVertex2f(40f, 13f);

            Gl.glColor3f(0.333333f, 0.333333f, 0.333333f);
            Gl.glVertex2f(40f, 10f);

            Gl.glEnd();

            Gl.glPopMatrix();
        }


        static void SemColisao()
        {
            if (tx < -40) { tx = 0; }
            Glut.glutPostRedisplay();
        }
        static void Colisao()
        {
            if (tx <= -37) { tx = -37; }
                Glut.glutPostRedisplay();
            if (tx >= 6) { tx = 6; }
                Glut.glutPostRedisplay();
        }

        static void DesenhaJogador()
        {
            
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            cenario();
            tiro();
            Jogador();
            Colisao();
            Glut.glutSwapBuffers();
        }
        //Funcoes para teclado (atribuicoes de teclas especiais)
        static void Mover(int key, int x, int y)
        {
            if (key == Glut.GLUT_KEY_LEFT) { tx -= 1; }
            if (key == Glut.GLUT_KEY_RIGHT) { tx += 1; }
        }
        //Funcoes para teclado (atribuicoes de teclas)
        static void Teclado(byte key, int x, int y)
        {
            if (key == 48) { sinal = 0; } //Tecla 0 Apaga o semaforo
            if (key == 49) { sinal = 1; } //Tecla 1 Acende a luz vermelha
            if (key == 50) { sinal = 2; } //Tecla 2 Acende a luz amarela
            if (key == 51) { sinal = 3; } //Tecla 3 Acende a luz verde
                                          //Redesenha o novo valor
            Glut.glutPostRedisplay();
        }
        static void Inicializa()
        {
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, 46.0, 0.0, 13.0);
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
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Teclado)); //Chama as funcoes do teclado
            Glut.glutMainLoop();
        }
    }
}
