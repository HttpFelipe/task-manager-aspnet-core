# Task Manager System

Este é um projeto de sistema de gerenciamento de tarefas desenvolvido usando ASP.NET Core com a utilização do Entity Framework Core. 
O sistema permite a criação, atualização, remoção e busca de tarefas por diferentes critérios, como título, data e status.

# Endpoints da API

A API possui os seguintes endpoints:

    GET /Tarefa/ObterTodos: Retorna todas as tarefas cadastradas no sistema.

    GET /Tarefa/ObterPorTitulo?titulo={titulo}: Retorna as tarefas que possuem o título correspondente ao valor fornecido.

    GET /Tarefa/ObterPorData?data={data}: Retorna as tarefas que possuem a data correspondente ao valor fornecido.

    GET /Tarefa/ObterPorStatus?status={status}: Retorna as tarefas que possuem o status correspondente ao valor fornecido. Os possíveis valores são "Pendente" ou "Finalizado".

    GET /Tarefa/{id}: Retorna a tarefa com o ID correspondente ao valor fornecido.

    PUT /Tarefa/{id}: Atualiza a tarefa com o ID correspondente ao valor fornecido com os dados fornecidos no corpo da requisição.

    DELETE /Tarefa/{id}: Remove a tarefa com o ID correspondente ao valor fornecido.

    POST /Tarefa: Cria uma nova tarefa com os dados fornecidos no corpo da requisição.

# Modelo de Dados

O modelo de dados da tarefa é representado pela classe Tarefa no namespace TaskManagerSystem.Models. A classe possui os seguintes campos:

    Id: Identificador único da tarefa (chave primária).

    Titulo: Título da tarefa.

    Descricao: Descrição da tarefa (opcional).

    Data: Data de criação da tarefa (definida automaticamente como a data atual).

    Status: Status da tarefa, que pode ser "Pendente" ou "Finalizado".

# Banco de Dados

O projeto utiliza o Entity Framework Core e um banco de dados local para armazenar as tarefas. A configuração do banco de dados é feita no arquivo appsettings.json na ConnectionString: "StandardConnection".
