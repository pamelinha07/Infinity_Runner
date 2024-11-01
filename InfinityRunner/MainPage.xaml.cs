namespace InfinityRunner;

public partial class MainPage : ContentPage
{
	bool estMorto=false;
	bool estPulando=false;
	const int tempoEntreFrames=25;
	int velocidade1=0;
	int velocidade2=0;
	int velocidade3=0;
	int velocidade=0;
	int largurJanela=0;
	int alturaJanela=0;
	public MainPage()
	{
		InitializeComponent();
	}
    protected override void OnSizeAllocated(double w, double h)
    {
        base.OnSizeAllocated(w, h);
		CorrigeTamanhoCenario(w,h);
		CalculaVelocidade(w);
    }
	void CalculaVelocidade(double w)
	{
		velocidade1=(int)(w*0.001);
		velocidade2=(int)(w*0.004);
		velocidade3=(int)(w*0.008);
	}
	void CorrigeTamanhoCenario(double w, double h)
	{
		foreach(var a in HSLayer1.Children)
		(a as Image ).WidthRequest = w;
		foreach(var a in HSLayer2.Children)
		(a as Image ).WidthRequest = w;
		foreach (var a in HSLayer3.Children)
		(a as Image ).WidthRequest = w;
		foreach( var a in HSLayerChao.Children)
		(a as Image ).WidthRequest = w;

		HSLayer1.WidthRequest=w*1.5;
		HSLayer2.WidthRequest=w*1.5;
		HSLayer3.WidthRequest=w*1.5;
		HSLayerChao.WidthRequest=w*1.5;
	}

	
}