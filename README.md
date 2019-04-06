# Trabalho prático com comunicação entre camadas utilizando .NET

PUC Minas - Pós graduação em Arquitetura de Sistemas Distribuídos

Disciplina de Arquitetura de Software na Plataforma .Net

## Componentes do grupo

- Cleber Amaral https://github.com/cgtamaral
- Lucas Duarte https://github.com/lucashdp
- Prince Sanis https://github.com/princesanis

## Sobre o projeto

Este trabalho consistiu na construção de uma aplicação capaz de realizar comunicação entre camadas utilizando .NET. 
A entradas de dados são realizadas via uma Web Api e Web Services. Os métodos recebem uma string como parâmetro e “passa para as outras camadas”. 
Utilizando Httpclient ou RestSharp será realizado uma chamada (post ou get) para o WCF (rest). 
O WCF vai colocar uma mensagem no MSMQ. 
Vai ter outro WCF que vai ficar lendo a fila e gravando em algum BD (pode ser qualquer BD).


### Visão arquitetural do sistema

O modelo a seguir apresenta visualmente a forma de comunicão e depencias entres os componentes:

![alt text](https://github.com/cgtamaral/trabalho-final-dotnet/blob/master/DiagramaComponentesComunicacao.jpg)
