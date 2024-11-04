﻿namespace InfinityRunner;

public partial class MainPage : ContentPage
{
	bool estaMorto=false;
	bool estaPulando=false;
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
	protected override void OnAppearing()
	{
		base.OnAppearing();
		Desenha();
	}
	void CalculaVelocidade(double w)
	{
		velocidade1=(int)(w*0.001);
		velocidade2=(int)(w*0.004);
		velocidade3=(int)(w*0.008);
	}
	void CorrigeTamanhoCenario(double w, double h)
	{
		foreach(var a in layerFundo.Children)
		(a as Image ).WidthRequest = w;
		foreach(var a in HSLayer2.Children)
		(a as Image ).WidthRequest = w;
		foreach (var a in HSLayer3.Children)
		(a as Image ).WidthRequest = w;
		foreach( var a in layerAsfalto.Children)
		(a as Image ).WidthRequest = w;

		layerFundo.WidthRequest=w*1.5;
		HSLayer2.WidthRequest=w*1.5;
		HSLayer3.WidthRequest=w*1.5;
		HSLayerAsfalto.WidthRequest=w*1.5;
	}
	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenario(layerFundo);
		GerenciaCenario(HSLayer2);
		GerenciaCenario(HSLayer3);
		GerenciaCenario(layerAsfalto);
	}
	void MoveCenario()
	{
	
		layerFundo.TranslationX -= velocidade1;
		HSLayer2.TranslationX -= velocidade2;
		HSLayer3.TranslationX -= velocidade3;
		layerAsfalto.TranslationX -= velocidade;
	}
	
	void GerenciaCenario(HorizontalStackLayout hsl)
	{
		var view = (hsl.Children.First() as Image);
		if(view.WidthRequest+hsl.TranslationX<0)
		{
			hsl.Children.Remove(view);
			hsl.Children.Add(view);
			hsl.TranslationX = view.TranslationX;
		}
	}
	async Task Desenha()
	{
		while(!estaMorto)
		{
			GerenciaCenarios();
			await Task.Delay(tempoEntreFrames);
		}
	}
	
	
	



	
}