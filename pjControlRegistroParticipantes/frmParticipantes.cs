namespace pjControlRegistroParticipantes
{
    public partial class frmParticipantes : Form
    {
        int num;
        int cJefe,cOperario,cAdministrativo, cPracticante ;
        public frmParticipantes()
        {
            InitializeComponent();
            tHora.Enabled = true;
        }

        private void frmParticipantes_Load(object sender, EventArgs e)
        {
            num++;
            lblfecha.Text = DateTime.Now.ToString("d");
            lblNumero.Text = num.ToString("D4");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            //CAPTURANDO DATOS
            DateTime fecha, hora;
            string participante, cargo;
            int numero;
            participante=txtParticipantes.Text;
            numero= int.Parse(lblNumero.Text);
            fecha=DateTime.Parse(lblfecha.Text);
            hora=DateTime.Parse(lblHora.Text);
            cargo=cboCargo.Text;

            //CONTABILIZAR LA CANTIDAD SEGUN LOS CARGOS
            
            switch(cargo)
            {
                case "JEFE": cJefe++; break;
                case "OPERARIO":cOperario++; break;
                case "ADMINISTRATIVO": cAdministrativo++; break;
                case "PRACTICANTE":cPracticante++; break;
            }

            //IMPRIMIENDO REGISTRO
            ListViewItem fila=new ListViewItem(numero.ToString());
            fila.SubItems.Add(participante);
            fila.SubItems.Add(cargo);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(hora.ToString("hh:mm:ss"));
            lvParticipantes.Items.Add(fila);

            //IMPRIMIENDO ESTADISTICAS
            lvEstadisticas.Items.Clear();
            string[] elementosFila = new string[2];
            ListViewItem row;

            //AÑADIMOS LA PRIMERA FILA lvESTADISTICAS
            elementosFila[0] = "JEFE";
            elementosFila[1] =cJefe.ToString();
            row= new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //SEGUNDA FILA
            elementosFila[0] = "OPERARIO";
            elementosFila[1]=cOperario.ToString();
            row= new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //TERCERA FILA
            elementosFila[0] = "ADMINISTRATIVO";
            elementosFila[1]= cPracticante.ToString();
            row= new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //CUARTA FILA

            elementosFila[0] = "PRACTICANTE";
            elementosFila[1] = cPracticante.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //Limpiando controles
            txtParticipantes.Clear();
            cboCargo.SelectedIndex = -1;
            txtParticipantes.Focus();



        }
    }
}