namespace Demo
{
    public class Funcionario: Pessoa
    {
        public double Salario { get; private set; }
        public NivelProfissional NivelProfissional { get; private set; }
        public IList<string>? Habilidades { get; private set; }

        public Funcionario(string nome, double salario)
        {
            Nome = String.IsNullOrEmpty(nome) ? "Fulano": nome;
            DefinirSalario(salario);
            DefinirHabilidades();
        }

        private void DefinirSalario(double salario)
        {
            if (salario < 500) throw new Exception("Salário inferior ao permitido");

            Salario = salario;
            if (salario < 2000) NivelProfissional = NivelProfissional.Junior;
            else if (salario >= 2000 && salario < 8000) NivelProfissional = NivelProfissional.Pleno;
            else if (salario >= 8000) NivelProfissional = NivelProfissional.Senior;
        }

        private void DefinirHabilidades()
        {
            var habilidadesBasicas = new List<string>()
            {
                "Lógica de programação",
                "OOP"
            };

            Habilidades = habilidadesBasicas;

            switch (NivelProfissional) 
            {
                case NivelProfissional.Pleno:
                    Habilidades.Add("Testes");
                    break;
                case NivelProfissional.Senior:
                    Habilidades.Add("Testes");
                    Habilidades.Add("Microserviços");
                    break;
            }
        }
    }
}
