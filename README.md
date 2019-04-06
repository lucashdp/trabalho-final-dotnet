# Trabalho prático com comunicação entre camadas utilizando .NET

PUC Minas - Pós graduação em Arquitetura de Sistemas Distribuídos

Disciplina de Arquitetura de Software na Plataforma .Net

## Alunos

- Cleber Amaral https://github.com/cgtamaral
- Lucas Duarte https://github.com/lucashdp
- Prince Sanis https://github.com/princesanis

## Sobre o projeto

Este trabalho consistiu na construção de uma aplicação capaz de realizar comunicação entre camadas utilizando .NET. 
As entradas de dados são realizadas via uma Web Api e Web Services. Foi utilizado comunicação Httpclient via Post para o envio de informações ao WCF (rest). O WCF Rest após recebimento da mensagem faz o envio para a fila MSMQ e no fim do fluxo existe um outro WCF que é responsavel por realizar a leitura da fila e realização da persistencia das mensagem na base dados que para o nosso exemplo foi utilizado MongoDB.


### Visão arquitetural do sistema

O modelo a seguir apresenta visualmente a forma de comunicão e depencias entres os componentes:

![alt text](https://github.com/cgtamaral/trabalho-final-dotnet/blob/master/DiagramaComponentesComunicacao.jpg)
