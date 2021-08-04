using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace firma
{   
    public partial class Form1 : Form
    {
        DBAccess objDBAccess = new DBAccess();
        bool adrese = false;
        bool angajati = false;
        bool clienti = false;
        bool comenzi = false;
        bool departamente = false;
        bool echipe = false;
        bool produse = false;
        bool proiecte = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtEchipe = new DataTable();
            string query = "select * from Echipe";
            objDBAccess.readDatathroughAdapter(query, dtEchipe);
            dataGridView1.DataSource = dtEchipe;
            objDBAccess.closeConn();
            adrese = false;
            angajati = false;
            clienti = false;
            comenzi = false;
            departamente = false;
            echipe = true;
            produse = false;
            proiecte = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dtDepartamente = new DataTable();
            string query = "select * from Departamente";
            objDBAccess.readDatathroughAdapter(query, dtDepartamente);
            dataGridView1.DataSource = dtDepartamente;
            objDBAccess.closeConn();
            adrese = false;
            angajati = false;
            clienti = false;
            comenzi = false;
            departamente = true;
            echipe = false;
            produse = false;
            proiecte = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dtClienti = new DataTable();
            string query = "select * from Clienti";
            objDBAccess.readDatathroughAdapter(query, dtClienti);
            dataGridView1.DataSource = dtClienti;
            objDBAccess.closeConn();
            adrese = false;
            angajati = false;
            clienti = true;
            comenzi = false;
            departamente = false;
            echipe = false;
            produse = false;
            proiecte = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dtAdrese = new DataTable();
            string query = "select * from Adrese";
            objDBAccess.readDatathroughAdapter(query, dtAdrese);
            dataGridView1.DataSource = dtAdrese;
            objDBAccess.closeConn();
            adrese = true;
            angajati = false;
            clienti = false;
            comenzi = false;
            departamente = false;
            echipe = false;
            produse = false;
            proiecte = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dtAngajati = new DataTable();
            string query = "select * from Angajati";
            objDBAccess.readDatathroughAdapter(query, dtAngajati);
            dataGridView1.DataSource = dtAngajati;
            objDBAccess.closeConn();
            adrese = false;
            angajati = true;
            clienti = false;
            comenzi = false;
            departamente = false;
            echipe = false;
            produse = false;
            proiecte = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dtProiecte = new DataTable();
            string query = "select * from Proiecte";
            objDBAccess.readDatathroughAdapter(query, dtProiecte);
            dataGridView1.DataSource = dtProiecte;
            objDBAccess.closeConn();
            adrese = false;
            angajati = false;
            clienti = false;
            comenzi = false;
            departamente = false;
            echipe = false;
            produse = false;
            proiecte = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable dtProduse = new DataTable();
            string query = "select * from Produse";
            objDBAccess.readDatathroughAdapter(query, dtProduse);
            dataGridView1.DataSource = dtProduse;
            objDBAccess.closeConn();
            adrese = false;
            angajati = false;
            clienti = false;
            comenzi = false;
            departamente = false;
            echipe = false;
            produse = true;
            proiecte = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataTable dtComenzi = new DataTable();
            string query = "select * from Comenzi";
            objDBAccess.readDatathroughAdapter(query, dtComenzi);
            dataGridView1.DataSource = dtComenzi;
            objDBAccess.closeConn();
            adrese = false;
            angajati = false;
            clienti = false;
            comenzi = true;
            departamente = false;
            echipe = false;
            produse = false;
            proiecte = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string id = textBox3.Text;
            string query;
            {
                
                if (id != "")
                {
                    DialogResult dialog = MessageBox.Show("Vrei sa stergi coloana cu id-ul:'" + id + "'", "Informatie stearsa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {

                        if (departamente)
                        {
                            query = "delete from Departamente where id_departament=" + id;
                            SqlCommand deleteCommand = new SqlCommand(query);
                            int row = objDBAccess.executeQuery(deleteCommand);
                            if (row == 1)
                            {
                                MessageBox.Show("Coloana a fost stearsa");
                                DataTable dtDepartamente = new DataTable();
                                string query1 = "select * from Departamente";
                                objDBAccess.readDatathroughAdapter(query1, dtDepartamente);
                                dataGridView1.DataSource = dtDepartamente;
                                objDBAccess.closeConn();
                            }
                            else
                            {
                                MessageBox.Show("Informatia nu exista");

                            }
                        }
                        else

                        if (echipe)
                        {
                            query = "delete from Echipe where id_echipa= " + id;
                            SqlCommand deleteCommand = new SqlCommand(query);
                            int row = objDBAccess.executeQuery(deleteCommand);
                            if (row == 1)

                            {
                                MessageBox.Show("Coloana a fost stearsa");
                                DataTable dtEchipe = new DataTable();
                                string query1 = "select * from Echipe";
                                objDBAccess.readDatathroughAdapter(query1, dtEchipe);
                                dataGridView1.DataSource = dtEchipe;
                                objDBAccess.closeConn();
                            }


                        }
                        else

                        {
                            MessageBox.Show("Informatia nu exista");

                        }

                        if (clienti)
                        {
                            query = "delete from Clienti where id_client= " + id;
                            SqlCommand deleteCommand = new SqlCommand(query);
                            int row = objDBAccess.executeQuery(deleteCommand);
                            if (row == 1)

                            {
                                MessageBox.Show("Coloana a fost stearsa");
                                DataTable dtClienti = new DataTable();
                                string query1 = "select * from Clienti";
                                objDBAccess.readDatathroughAdapter(query1, dtClienti);
                                dataGridView1.DataSource = dtClienti;
                                objDBAccess.closeConn();
                            }


                        }
                        else

                        {
                            MessageBox.Show("Informatia nu exista");

                        }
                        if (adrese)
                        {
                            query = "delete from Adrese where id_adresa= " + id;
                            SqlCommand deleteCommand = new SqlCommand(query);
                            int row = objDBAccess.executeQuery(deleteCommand);
                            if (row == 1)

                            {
                                MessageBox.Show("Coloana a fost stearsa");
                                DataTable dtAdrese = new DataTable();
                                string query1 = "select * from Adrese";
                                objDBAccess.readDatathroughAdapter(query1, dtAdrese);
                                dataGridView1.DataSource = dtAdrese;
                                objDBAccess.closeConn();
                            }


                        }
                        else

                        {
                            MessageBox.Show("Informatia nu exista");

                        }
                        if (proiecte)
                        {
                            query = "delete from Proiecte where id_proiect= " + id;
                            SqlCommand deleteCommand = new SqlCommand(query);
                            int row = objDBAccess.executeQuery(deleteCommand);
                            if (row == 1)

                            {
                                MessageBox.Show("Coloana a fost stearsa");
                                DataTable dtProiecte = new DataTable();
                                string query1 = "select * from Proiecte";
                                objDBAccess.readDatathroughAdapter(query1, dtProiecte);
                                dataGridView1.DataSource = dtProiecte;
                                objDBAccess.closeConn();
                            }


                        }
                        else

                        {
                            MessageBox.Show("Informatia nu exista");

                        }
                        if (angajati)
                        {
                            query = "delete from Angajati where id_angajat= " + id;
                            SqlCommand deleteCommand = new SqlCommand(query);
                            int row = objDBAccess.executeQuery(deleteCommand);
                            if (row == 1)

                            {
                                MessageBox.Show("Coloana a fost stearsa");
                                DataTable dtAngajati = new DataTable();
                                string query1 = "select * from Angajati";
                                objDBAccess.readDatathroughAdapter(query1, dtAngajati);
                                dataGridView1.DataSource = dtAngajati;
                                objDBAccess.closeConn();
                            }


                        }
                        else

                        {
                            MessageBox.Show("Informatia nu exista");

                        }
                        if (produse)
                        {
                            query = "delete from Produse where id_produs= " + id;
                            SqlCommand deleteCommand = new SqlCommand(query);
                            int row = objDBAccess.executeQuery(deleteCommand);
                            if (row == 1)

                            {
                                MessageBox.Show("Coloana a fost stearsa");
                                DataTable dtProduse = new DataTable();
                                string query1 = "select * from Produse";
                                objDBAccess.readDatathroughAdapter(query1, dtProduse);
                                dataGridView1.DataSource = dtProduse;
                                objDBAccess.closeConn();
                            }


                        }
                        else

                        {
                            MessageBox.Show("Informatia nu exista");

                        }
                        if (comenzi)
                        {
                            query = "delete from Comenzi where id_comanda= " + id;
                            SqlCommand deleteCommand = new SqlCommand(query);
                            int row = objDBAccess.executeQuery(deleteCommand);
                            if (row == 1)

                            {
                                MessageBox.Show("Coloana a fost stearsa");
                                DataTable dtComenzi = new DataTable();
                                string query1 = "select * from Comenzi";
                                objDBAccess.readDatathroughAdapter(query1, dtComenzi);
                                dataGridView1.DataSource = dtComenzi;
                                objDBAccess.closeConn();
                            }


                        }
                        else

                        {
                            MessageBox.Show("Informatia nu exista");

                        }


                    }


                }
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            string query = "select a.nume, a.prenume ,  d.nume_departament, e.nume " +
                "from Angajati a, Departamente d, Echipe e " +
                "where a.id_echipa = e.id_echipa and a.id_departament=d.id_departament and a.numar_telefon like '%46%' and a.salariu>6000;";
            
             
            DataTable dttable = new DataTable();
            objDBAccess.readDatathroughAdapter(query, dttable);
            dataGridView2.DataSource = dttable;
            objDBAccess.closeConn();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string query = "select d.nume_departament , COUNT(*) as 'Numar_angajati' " +
                " from Departamente d, Angajati a" +
                " where d.id_departament = a.id_departament" +
                " group by d.nume_departament" +
                " having COUNT(*)>5; ";
            DataTable dttable = new DataTable();
            objDBAccess.readDatathroughAdapter(query, dttable);
            dataGridView3.DataSource = dttable;
            objDBAccess.closeConn();
        }


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string query = "create view jud as (select c.nume, c.prenume, a.judet from Adrese a, Clienti c where a.id_client = c.id_client and a.judet like('Arges')); ";
            SqlCommand createviewCommand = new SqlCommand(query);
            int row = objDBAccess.executeQuery(createviewCommand);
            if (row != 0)
            {
                MessageBox.Show("Vizualizarea a fost creata");
                button13.Visible = true;

            }
            else

            {
                MessageBox.Show("Vizualizarea deja exista");

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string query = "select *" +
                "from jud";
            DataTable dttable = new DataTable();
            objDBAccess.readDatathroughAdapter(query, dttable);
            dataGridView4.DataSource = dttable;
            objDBAccess.closeConn();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string query = "create view Nume_complet as (select nume + ' ' + prenume as 'Nume_complet' from Angajati); ";
            SqlCommand createviewCommand = new SqlCommand(query);
            int row = objDBAccess.executeQuery(createviewCommand);
            if (row != 0)
            {
                MessageBox.Show("Vizualizarea a fost creata");
                button15.Visible = true;

            }
            else

            {
                MessageBox.Show("Vizualizarea deja exista");

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            string query = "select *" +
                "from Nume_complet";
            DataTable dttable1 = new DataTable();
            objDBAccess.readDatathroughAdapter(query, dttable1);
            dataGridView4.DataSource = dttable1;
            objDBAccess.closeConn();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            string query = "create view nr_ang_dep as ( select d.nume_departament , count(*) as 'Numar_angajati' from Departamente d, Angajati a where d.id_departament = a.id_departament group by d.nume_departament having count(*)>2;)";
            SqlCommand createCommand = new SqlCommand(query);
            int row = objDBAccess.executeQuery(createCommand);
            if (row != 0)
            {
                MessageBox.Show("Vizualizarea a fost creata");
                button17.Visible = true;
            }
            else

            {
                MessageBox.Show("Vizualizarea deja exista");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string query = "select *" +
            "from nr_ang_dep";
            DataTable dttable2 = new DataTable();
            objDBAccess.readDatathroughAdapter(query, dttable2);
            dataGridView4.DataSource = dttable2;
            objDBAccess.closeConn();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

