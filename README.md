<h1 align="center"> 🛠️ Aplicação para cadastro de pessoas </h1>
Esta é uma aplicação proposta como desafio para participação no processo seletivo
da empresa <b>Via Aroma</b> na vaga como desenvolvedor C#.
<hr />

## 🔍 Sobre
Essa aplicação foi desenvolvida no Visual Studio Community com base nas boas práticas de programação do padrão de arquitetura **MVP (Model-View-Presenter)**.
Esse é um padrão de arquitetura especialmente indicado para aplicações utilizando Windows Forms que lida com conceitos como DIP (Inversão de dependência), Clean code e DDD.

Esse padrão de arquitetura tem o  objetivo principal de separar a interface de usuário dos mecanismos de regras de negócio. Exemplo da relação de cada camada dessa arquitetura:

![image](https://user-images.githubusercontent.com/22736436/214003296-6ed66d60-99f2-45fa-a587-54690d5fb6c4.png)

Essa separação facilita muito a manutenção do código, desacoplamento de funções para ser possível de utilizar me outras aplicações se necessário e simplifica o processo de desenvolvimento de novas funcionalidades ou regras de negócio.

Por meio dessa aplicação é possível persistir uma base de dados e manipular ela através dos Windows Forms por ações de **cadastro**, **pesquisa**, **alteração** e **exclusão** de clientes fictícios. Além de ser possível gerar um relatório por meio do Report Viewer listando os clientes diretamente do banco de dados.

## 🧑‍💻 Tecnologias
* C# 
* Windows Forms
* Report Viewer
* SQL Server

## ⚙️ Como executar?
Após clonar a aplicação localmente, no seu Visual Studio e instalar os pacotes necessários (SQLClient) basta importar o arquivo PeopleDB que vai criar o banco de dados e tabela para o seu servidor de banco de dados dentro do SQL Server.

Lembrando que precisa também ter o banco de dados instalado localmente e configurado com as credenciais corretas no arquivo 'Settings.settings':

```json
  Data Source=nomeDoSeuServidor;Initial Catalog=teste_cadastros;Integrated Security=True;Encrypt=False
```

Também é necessário copiar e colar essa exata mesma string de conexão dentro do arquivo PeopleFormReport.cs pois esse ficará encarregado de gerar o relatório da tabela de pessoas do banco de dados.

![Captura de tela 2023-01-23 060049](https://user-images.githubusercontent.com/22736436/214005318-f71bcf3b-fb6e-4cb2-a8a1-3118b93fdcec.png)

![Captura de tela 2023-01-23 060019](https://user-images.githubusercontent.com/22736436/214005220-669f497e-39cc-4b33-86c5-a7af37ac9017.png)
