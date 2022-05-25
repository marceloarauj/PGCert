Autor: Marcelo de Araújo Elias
Ferramentas: 
- .NET 6.0 (core)
- SQL Server 2019 express

Bibliotecas:
- Swagger
- Entity Framework

# Algumas considerações

- Como a chave NSU é única, considerei ela como chave primária

- Na data de aprovação ou reprovação da transação considerei a data atual (fiquei em dúvida se o vendedor informava ou não)

- Considerei a reprovação somente quando o cartão era 5999 (não sabia quais seriam outros casos para reprovação, maior parte dos dados passavam pelas validations)

- Na antecipação era necessário armazenar um lista de transações (considerei utilizar uma nova entidade para armazenar o id da antecipação e a chave NSU da trasação)
