namespace InfinityRunner
public class Player
{
    public delegate void Callback();
    public class Player : Animacao
    {
        public Player (Image a) : base (a)
        {
            for (int i=1; i <=; i++)
                 animacao1.Add ($"{i.ToString("D2")}.png");
            for (int i=1; i<=; i++)
                animacao2.Add ($"{i.ToString("D2")}.png");
            SetAnimacaoAtiva(1);
        }
        public void Die()
        {
            loop+false;
            SetAnimacaoativa(2);
        }
        public void Run()
        {
            loop=true;
            SetAnimacaoAtiva(1);
            Play();
        }
    }
}