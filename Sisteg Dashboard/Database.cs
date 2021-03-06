﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace Sisteg_Dashboard
{
    class Database
    {
        private static SQLiteConnection connection;

        //INICIA CONEXÃO COM BASE NA LOCALIZAÇÃO DO BANCO DE DADOS INTERNO DA APLICAÇÃO
        private static SQLiteConnection databaseConnection()
        {
            connection = new SQLiteConnection("Data Source=C:\\Users\\Wesley Ribeiro\\source\\repos\\Sisteg Dashboard\\Sisteg Dashboard\\database\\sistegDatabase.db");
            connection.Open();
            return connection;
        }

        //FUNÇÃO QUE CHECA SE A TRANSAÇÃO CORRESPONDE À UMA RECEITAO OU DESPESA
        public static Boolean checkIfItIsExpense(string id, string value, string date, string category)
        {
            DataTable dataTable = new DataTable();
            try
            {
                DateTime dateTime = DateTime.Parse(date);
                string formatForSQLite = dateTime.ToString("yyyy-MM-dd");
                string query = "SELECT idDespesa FROM despesa WHERE idDespesa = " + id + " AND valorDespesa = " + value + " AND dataTransacao = '" + formatForSQLite + "' AND categoriaDespesa = '" + category + "';";
                dataTable = Database.query(query);
                if(dataTable.Rows.Count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //LISTAR RECEITAS OU DESPESAS
        public static DataTable readExpensesOrIncomes(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = Database.query(query);
                return dataTable;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //FUNÇÃO QUE EXECUTA UMA CONSULTA QUALQUER
        public static DataTable query(string query)
        {
            SQLiteDataAdapter dataAdapter = null;
            DataTable dataTable = new DataTable();
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                command.CommandText = query;
                dataAdapter = new SQLiteDataAdapter(command.CommandText, databaseConnection());
                dataAdapter.Fill(dataTable);
                connection.Close();
                return dataTable;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        //CADASTRAR RECEITA
        public static Boolean newIncome(Income income)
        {
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                DateTime dateTime = DateTime.Parse(income.dataTransacao.ToString());
                string formatForSQLite = dateTime.ToString("yyyy-MM-dd");
                command.CommandText = "INSERT INTO receita (idConta, valorReceita, descricaoReceita, dataTransacao, categoriaReceita, observacoesReceita, recebimentoConfirmado, repetirParcelarReceita, valorFixoReceita, repeticoesValorFixoReceita, parcelarValorReceita, parcelasReceita, periodoRepetirParcelarReceita) VALUES (@idConta, @valorReceita, @descricaoReceita, @dataTransacao, @categoriaReceita, @observacoesReceita, @recebimentoConfirmado, @repetirParcelarReceita, @valorFixoReceita, @repeticoesValorFixoReceita, @parcelarValorReceita, @parcelasReceita, @periodoRepetirParcelarReceita)";
                command.Parameters.AddWithValue("@idConta", income.idConta);
                command.Parameters.AddWithValue("@valorReceita", income.valorReceita);
                command.Parameters.AddWithValue("@descricaoReceita", income.descricaoReceita);
                command.Parameters.AddWithValue("@dataTransacao", formatForSQLite);
                command.Parameters.AddWithValue("@categoriaReceita", income.categoriaReceita);
                command.Parameters.AddWithValue("@observacoesReceita", income.observacoesReceita);
                command.Parameters.AddWithValue("@recebimentoConfirmado", income.recebimentoConfirmado);
                command.Parameters.AddWithValue("@repetirParcelarReceita", income.repetirParcelarReceita);
                command.Parameters.AddWithValue("@valorFixoReceita", income.valorFixoReceita);
                command.Parameters.AddWithValue("@repeticoesValorFixoReceita", income.repeticoesValorFixoReceita);
                command.Parameters.AddWithValue("@parcelarValorReceita", income.parcelarValorReceita);
                command.Parameters.AddWithValue("@parcelasReceita", income.parcelasReceita);
                command.Parameters.AddWithValue("@periodoRepetirParcelarReceita", income.periodoRepetirParcelarReceita);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }catch(Exception exception)
            {
                throw exception;
            }
        }

        //ATUALIZAR RECEITA
        public static Boolean updateIncome(Income income)
        {
            SQLiteDataAdapter dataAdapter = null;
            DataTable dataTable = new DataTable();
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                DateTime dateTime = DateTime.Parse(income.dataTransacao.ToString());
                string formatForSQLite = dateTime.ToString("yyyy-MM-dd");
                command.CommandText = "UPDATE receita SET idConta = @idConta, valorReceita = @valorReceita, descricaoReceita = @descricaoReceita, dataTransacao = @dataTransacao, categoriaReceita = @categoriaReceita, observacoesReceita = @observacoesReceita, recebimentoConfirmado = @recebimentoConfirmado, repetirParcelarReceita = @repetirParcelarReceita, valorFixoReceita = @valorFixoReceita, repeticoesValorFixoReceita = @repeticoesValorFixoReceita, parcelarValorReceita = @parcelarValorReceita, parcelasReceita = @parcelasReceita, periodoRepetirParcelarReceita = @periodoRepetirParcelarReceita WHERE idReceita = @idReceita;";
                command.Parameters.AddWithValue("@idConta", income.idConta);
                command.Parameters.AddWithValue("@valorReceita", income.valorReceita);
                command.Parameters.AddWithValue("@descricaoReceita", income.descricaoReceita);
                command.Parameters.AddWithValue("@dataTransacao", formatForSQLite);
                command.Parameters.AddWithValue("@categoriaReceita", income.categoriaReceita);
                command.Parameters.AddWithValue("@observacoesReceita", income.observacoesReceita);
                command.Parameters.AddWithValue("@recebimentoConfirmado", income.recebimentoConfirmado);
                command.Parameters.AddWithValue("@repetirParcelarReceita", income.repetirParcelarReceita);
                command.Parameters.AddWithValue("@valorFixoReceita", income.valorFixoReceita);
                command.Parameters.AddWithValue("@repeticoesValorFixoReceita", income.repeticoesValorFixoReceita);
                command.Parameters.AddWithValue("@parcelarValorReceita", income.parcelarValorReceita);
                command.Parameters.AddWithValue("@parcelasReceita", income.parcelasReceita);
                command.Parameters.AddWithValue("@periodoRepetirParcelarReceita", income.periodoRepetirParcelarReceita);
                command.Parameters.AddWithValue("@idReceita", income.idReceita);
                dataAdapter = new SQLiteDataAdapter(command.CommandText, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //EXCLUIR RECEITA
        public static Boolean deleteIncome(Income income)
        {
            SQLiteDataAdapter dataAdapter = null;
            DataTable dataTable = new DataTable();
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                command.CommandText = "DELETE FROM receita WHERE idReceita = @idReceita;";
                command.Parameters.AddWithValue("@idReceita", income.idReceita);
                dataAdapter = new SQLiteDataAdapter(command.CommandText, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //CADASTRAR DESPESA
        public static Boolean newExpense(Expense expense)
        {
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                DateTime dateTime = DateTime.Parse(expense.dataTransacao.ToString());
                string formatForSQLite = dateTime.ToString("yyyy-MM-dd");
                command.CommandText = "INSERT INTO despesa (idConta, valorDespesa, descricaoDespesa, dataTransacao, categoriaDespesa, observacoesDespesa, pagamentoConfirmado, repetirParcelarDespesa, valorFixoDespesa, repeticoesValorFixoDespesa, parcelarValorDespesa, parcelasDespesa, periodoRepetirParcelarDespesa) VALUES (@idConta, @valorDespesa, @descricaoDespesa, @dataTransacao, @categoriaDespesa, @observacoesDespesa, @pagamentoConfirmado, @repetirParcelarDespesa, @valorFixoDespesa, @repeticoesValorFixoDespesa, @parcelarValorDespesa, @parcelasDespesa, @periodoRepetirParcelarDespesa)";
                command.Parameters.AddWithValue("@idConta", expense.idConta);
                command.Parameters.AddWithValue("@valorDespesa", expense.valorDespesa);
                command.Parameters.AddWithValue("@descricaoDespesa", expense.descricaoDespesa);
                command.Parameters.AddWithValue("@dataTransacao", formatForSQLite);
                command.Parameters.AddWithValue("@categoriaDespesa", expense.categoriaDespesa);
                command.Parameters.AddWithValue("@observacoesDespesa", expense.observacoesDespesa);
                command.Parameters.AddWithValue("@pagamentoConfirmado", expense.pagamentoConfirmado);
                command.Parameters.AddWithValue("@repetirParcelarDespesa", expense.repetirParcelarDespesa);
                command.Parameters.AddWithValue("@valorFixoDespesa", expense.valorFixoDespesa);
                command.Parameters.AddWithValue("@repeticoesValorFixoDespesa", expense.repeticoesValorFixoDespesa);
                command.Parameters.AddWithValue("@parcelarValorDespesa", expense.parcelarValorDespesa);
                command.Parameters.AddWithValue("@parcelasDespesa", expense.parcelasDespesa);
                command.Parameters.AddWithValue("@periodoRepetirParcelarDespesa", expense.periodoRepetirParcelarDespesa);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //ATUALIZAR DESPESA
        public static Boolean updateExpense(Expense expense)
        {
            SQLiteDataAdapter dataAdapter = null;
            DataTable dataTable = new DataTable();
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                DateTime dateTime = DateTime.Parse(expense.dataTransacao.ToString());
                string formatForSQLite = dateTime.ToString("yyyy-MM-dd");
                command.CommandText = "UPDATE despesa SET idConta = @idConta, valorDespesa = @valorDespesa, descricaoDespesa = @descricaoDespesa, dataTransacao = @dataTransacao, categoriaDespesa = @categoriaDespesa, observacoesDespesa = @observacoesDespesa, pagamentoConfirmado = @pagamentoConfirmado, repetirParcelarDespesa = @repetirParcelarDespesa, valorFixoDespesa = @valorFixoDespesa, repeticoesValorFixoDespesa = @repeticoesValorFixoDespesa, parcelarValorDespesa = @parcelarValorDespesa, parcelasDespesa = @parcelasDespesa, periodoRepetirParcelarDespesa = @periodoRepetirParcelarDespesa WHERE idDespesa = @idDespesa;";
                command.Parameters.AddWithValue("@idConta", expense.idConta);
                command.Parameters.AddWithValue("@valorDespesa", expense.valorDespesa);
                command.Parameters.AddWithValue("@descricaoDespesa", expense.descricaoDespesa);
                command.Parameters.AddWithValue("@dataTransacao", formatForSQLite);
                command.Parameters.AddWithValue("@categoriaDespesa", expense.categoriaDespesa);
                command.Parameters.AddWithValue("@observacoesDespesa", expense.observacoesDespesa);
                command.Parameters.AddWithValue("@pagamentoConfirmado", expense.pagamentoConfirmado);
                command.Parameters.AddWithValue("@repetirParcelarDespesa", expense.repetirParcelarDespesa);
                command.Parameters.AddWithValue("@valorFixoDespesa", expense.valorFixoDespesa);
                command.Parameters.AddWithValue("@repeticoesValorFixoDespesa", expense.repeticoesValorFixoDespesa);
                command.Parameters.AddWithValue("@parcelarValorDespesa", expense.parcelarValorDespesa);
                command.Parameters.AddWithValue("@parcelasDespesa", expense.parcelasDespesa);
                command.Parameters.AddWithValue("@periodoRepetirParcelarDespesa", expense.periodoRepetirParcelarDespesa);
                command.Parameters.AddWithValue("@idDespesa", expense.idDespesa);
                dataAdapter = new SQLiteDataAdapter(command.CommandText, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //EXCLUIR DESPESA
        public static Boolean deleteExpense(Expense expense)
        {
            SQLiteDataAdapter dataAdapter = null;
            DataTable dataTable = new DataTable();
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                command.CommandText = "DELETE FROM despesa WHERE idDespesa = @idDespesa;";
                command.Parameters.AddWithValue("@idDespesa", expense.idDespesa);
                dataAdapter = new SQLiteDataAdapter(command.CommandText, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //ADICIONAR CLIENTE
        public static Boolean newClient(Client client)
        {
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                command.CommandText = "INSERT INTO cliente (nomeCliente, enderecoCliente, numeroResidencia, cidadeCliente, estadoCliente, primeiroTelefoneCliente, tipoPrimeiroTelefoneCliente, segundoTelefoneCliente, tipoSegundoTelefoneCliente, terceirotelefoneCliente, tipoTerceiroTelefoneCliente) VALUES (@nomeCliente, @enderecoCliente, @numeroResidencia, @cidadeCliente, @estadoCliente, @primeiroTelefoneCliente, @tipoPrimeiroTelefoneCliente, @segundoTelefoneCliente, @tipoSegundoTelefoneCliente, @terceiroTelefoneCliente, @tipoTerceiroTelefoneCliente)";
                command.Parameters.AddWithValue("@nomeCliente", client.nomeCliente);
                command.Parameters.AddWithValue("@enderecoCliente", client.enderecoCliente);
                command.Parameters.AddWithValue("@numeroResidencia", client.numeroResidencia);
                command.Parameters.AddWithValue("@cidadeCliente", client.cidadeCliente);
                command.Parameters.AddWithValue("@estadoCliente", client.estadoCliente);
                command.Parameters.AddWithValue("@primeiroTelefoneCliente", client.primeiroTelefoneCliente);
                command.Parameters.AddWithValue("@tipoPrimeiroTelefoneCliente", client.tipoPrimeiroTelefoneCliente);
                command.Parameters.AddWithValue("@segundoTelefoneCliente", client.segundoTelefoneCliente);
                command.Parameters.AddWithValue("@tipoSegundoTelefoneCliente", client.tipoSegundoTelefoneCliente);
                command.Parameters.AddWithValue("@terceiroTelefoneCliente", client.terceiroTelefoneCliente);
                command.Parameters.AddWithValue("@tipoTerceiroTelefoneCliente", client.tipoTerceiroTelefoneCliente);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        //ATUALIZAR CLIENTE
        public static Boolean updateClient(Client client)
        {
            SQLiteDataAdapter dataAdapter = null;
            DataTable dataTable = new DataTable();
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                command.CommandText = "UPDATE cliente SET nomeCliente = @nomeCliente, enderecoCliente = @enderecoCliente, numeroResidencia = @numeroResidencia, cidadeCliente = @cidadeCliente, estadoCliente = @estadoCliente, primeiroTelefoneCliente = @primeiroTelefoneCliente, tipoPrimeiroTelefoneCliente = @tipoPrimeiroTelefoneCliente, segundoTelefoneCliente = @segundoTelefoneCliente, tipoSegundoTelefoneCliente = @tipoSegundoTelefoneCliente, terceiroTelefoneCliente = @terceiroTelefoneCliente, tipoTerceiroTelefoneCliente = @tipoTerceiroTelefoneCliente WHERE idCliente = @idCliente;";
                command.Parameters.AddWithValue("@nomeCliente", client.nomeCliente);
                command.Parameters.AddWithValue("@enderecoCliente", client.enderecoCliente);
                command.Parameters.AddWithValue("@numeroResidencia", client.numeroResidencia);
                command.Parameters.AddWithValue("@cidadeCliente", client.cidadeCliente);
                command.Parameters.AddWithValue("@estadoCliente", client.estadoCliente);
                command.Parameters.AddWithValue("@primeiroTelefoneCliente", client.primeiroTelefoneCliente);
                command.Parameters.AddWithValue("@tipoPrimeiroTelefoneCliente", client.tipoPrimeiroTelefoneCliente);
                command.Parameters.AddWithValue("@segundoTelefoneCliente", client.segundoTelefoneCliente);
                command.Parameters.AddWithValue("@tipoSegundoTelefoneCliente", client.tipoSegundoTelefoneCliente);
                command.Parameters.AddWithValue("@terceiroTelefoneCliente", client.terceiroTelefoneCliente);
                command.Parameters.AddWithValue("@tipoTerceiroTelefoneCliente", client.tipoTerceiroTelefoneCliente);
                command.Parameters.AddWithValue("@idCliente", client.idCliente);
                dataAdapter = new SQLiteDataAdapter(command.CommandText, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //EXCLUIR CLIENTE
        public static Boolean deleteClient(Client client)
        {
            SQLiteDataAdapter dataAdapter = null;
            DataTable dataTable = new DataTable();
            try
            {
                var connection = databaseConnection();
                var commandClient = databaseConnection().CreateCommand();
                commandClient.CommandText = "DELETE FROM cliente WHERE idCliente = @idCliente;";
                commandClient.Parameters.AddWithValue("@idCliente", client.idCliente);
                dataAdapter = new SQLiteDataAdapter(commandClient.CommandText, connection);
                commandClient.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //CADASTRAR PRODUTO
        public static Boolean newProduct(Product product)
        {
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                command.CommandText = "INSERT INTO produto (idFornecedor, nomeProduto, valorUnitario) VALUES (@idFornecedor, @nomeProduto, @valorUnitario)";
                command.Parameters.AddWithValue("@idFornecedor", product.idFornecedor);
                command.Parameters.AddWithValue("@nomeProduto", product.nomeProduto);
                command.Parameters.AddWithValue("@valorUnitario", product.valorUnitario);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //ATUALIZAR PRODUTO
        public static Boolean updateProduct(Product product)
        {
            SQLiteDataAdapter dataAdapter = null;
            DataTable dataTable = new DataTable();
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                command.CommandText = "UPDATE produto SET idFornecedor = @idFornecedor, nomeProduto = @nomeProduto, valorUnitario = @valorUnitario WHERE idProduto = @idProduto;";
                command.Parameters.AddWithValue("@idFornecedor", product.idFornecedor);
                command.Parameters.AddWithValue("@nomeProduto", product.nomeProduto);
                command.Parameters.AddWithValue("@valorUnitario", product.valorUnitario);
                command.Parameters.AddWithValue("@idProduto", product.idProduto);
                dataAdapter = new SQLiteDataAdapter(command.CommandText, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //EXCLUIR PRODUTO
        public static Boolean deleteProduct(Product product)
        {
            SQLiteDataAdapter dataAdapter = null;
            DataTable dataTable = new DataTable();
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                command.CommandText = "DELETE FROM produto WHERE idProduto = @idProduto;";
                command.Parameters.AddWithValue("@idProduto", product.idProduto);
                dataAdapter = new SQLiteDataAdapter(command.CommandText, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //EXCLUIR TODOS OS PRODUTOS
        public static Boolean deleteAllProducts(Supplier supplier)
        {
            SQLiteDataAdapter dataAdapter = null;
            DataTable dataTable = new DataTable();
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                command.CommandText = "DELETE FROM produto WHERE idFornecedor = @idFornecedor;";
                command.Parameters.AddWithValue("@idFornecedor", supplier.idFornecedor);
                dataAdapter = new SQLiteDataAdapter(command.CommandText, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //ADICIONAR FORNECEDOR
        public static Boolean newSupplier(Supplier supplier)
        {
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                command.CommandText = "INSERT INTO fornecedor (nomeFornecedor, enderecoFornecedor, numeroResidencia, cidadeFornecedor, estadoFornecedor, emailFornecedor, primeiroTelefoneFornecedor, tipoPrimeiroTelefoneFornecedor, segundoTelefoneFornecedor, tipoSegundoTelefoneFornecedor, terceirotelefoneFornecedor, tipoTerceiroTelefoneFornecedor) VALUES (@nomeFornecedor, @enderecoFornecedor, @numeroResidencia, @cidadeFornecedor, @estadoFornecedor, @emailFornecedor, @primeiroTelefoneFornecedor, @tipoPrimeiroTelefoneFornecedor, @segundoTelefoneFornecedor, @tipoSegundoTelefoneFornecedor, @terceiroTelefoneFornecedor, @tipoTerceiroTelefoneFornecedor)";
                command.Parameters.AddWithValue("@nomeFornecedor", supplier.nomeFornecedor);
                command.Parameters.AddWithValue("@enderecoFornecedor", supplier.enderecoFornecedor);
                command.Parameters.AddWithValue("@numeroResidencia", supplier.numeroResidencia);
                command.Parameters.AddWithValue("@cidadeFornecedor", supplier.cidadeFornecedor);
                command.Parameters.AddWithValue("@estadoFornecedor", supplier.estadoFornecedor);
                command.Parameters.AddWithValue("@emailFornecedor", supplier.emailFornecedor);
                command.Parameters.AddWithValue("@primeiroTelefoneFornecedor", supplier.primeiroTelefoneFornecedor);
                command.Parameters.AddWithValue("@tipoPrimeiroTelefoneFornecedor", supplier.tipoPrimeiroTelefoneFornecedor);
                command.Parameters.AddWithValue("@segundoTelefoneFornecedor", supplier.segundoTelefoneFornecedor);
                command.Parameters.AddWithValue("@tipoSegundoTelefoneFornecedor", supplier.tipoSegundoTelefoneFornecedor);
                command.Parameters.AddWithValue("@terceiroTelefoneFornecedor", supplier.terceiroTelefoneFornecedor);
                command.Parameters.AddWithValue("@tipoTerceiroTelefoneFornecedor", supplier.tipoTerceiroTelefoneFornecedor);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        //ATUALIZAR FORNECEDOR
        public static Boolean updateSupplier(Supplier supplier)
        {
            SQLiteDataAdapter dataAdapter = null;
            DataTable dataTable = new DataTable();
            try
            {
                var connection = databaseConnection();
                var command = databaseConnection().CreateCommand();
                command.CommandText = "UPDATE fornecedor SET nomeFornecedor = @nomeFornecedor, enderecoFornecedor = @enderecoFornecedor, numeroResidencia = @numeroResidencia, cidadeFornecedor = @cidadeFornecedor, estadoFornecedor = @estadoFornecedor,  emailFornecedor = @emailFornecedor, primeiroTelefoneFornecedor = @primeiroTelefoneFornecedor, tipoPrimeiroTelefoneFornecedor = @tipoPrimeiroTelefoneFornecedor, segundoTelefoneFornecedor = @segundoTelefoneFornecedor, tipoSegundoTelefoneFornecedor = @tipoSegundoTelefoneFornecedor, terceiroTelefoneFornecedor = @terceiroTelefoneFornecedor, tipoTerceiroTelefoneFornecedor = @tipoTerceiroTelefoneFornecedor WHERE idFornecedor = @idFornecedor;";
                command.Parameters.AddWithValue("@nomeFornecedor", supplier.nomeFornecedor);
                command.Parameters.AddWithValue("@enderecoFornecedor", supplier.enderecoFornecedor);
                command.Parameters.AddWithValue("@numeroResidencia", supplier.numeroResidencia);
                command.Parameters.AddWithValue("@cidadeFornecedor", supplier.cidadeFornecedor);
                command.Parameters.AddWithValue("@estadoFornecedor", supplier.estadoFornecedor);
                command.Parameters.AddWithValue("@emailFornecedor", supplier.emailFornecedor);
                command.Parameters.AddWithValue("@primeiroTelefoneFornecedor", supplier.primeiroTelefoneFornecedor);
                command.Parameters.AddWithValue("@tipoPrimeiroTelefoneFornecedor", supplier.tipoPrimeiroTelefoneFornecedor);
                command.Parameters.AddWithValue("@segundoTelefoneFornecedor", supplier.segundoTelefoneFornecedor);
                command.Parameters.AddWithValue("@tipoSegundoTelefoneFornecedor", supplier.tipoSegundoTelefoneFornecedor);
                command.Parameters.AddWithValue("@terceiroTelefoneFornecedor", supplier.terceiroTelefoneFornecedor);
                command.Parameters.AddWithValue("@tipoTerceiroTelefoneFornecedor", supplier.tipoTerceiroTelefoneFornecedor);
                command.Parameters.AddWithValue("@idFornecedor", supplier.idFornecedor);
                dataAdapter = new SQLiteDataAdapter(command.CommandText, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //EXCLUIR FORNECEDOR
        public static Boolean deleteSupplier(Supplier supplier)
        {
            SQLiteDataAdapter dataAdapter = null;
            DataTable dataTable = new DataTable();
            try
            {
                var connection = databaseConnection();
                var commandClient = databaseConnection().CreateCommand();
                commandClient.CommandText = "DELETE FROM fornecedor WHERE idFornecedor = @idFornecedor;";
                commandClient.Parameters.AddWithValue("@idFornecedor", supplier.idFornecedor);
                dataAdapter = new SQLiteDataAdapter(commandClient.CommandText, connection);
                commandClient.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
