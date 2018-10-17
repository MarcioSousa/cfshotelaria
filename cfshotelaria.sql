-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: 17-Out-2018 às 19:59
-- Versão do servidor: 5.7.19
-- PHP Version: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cfshotelaria`
--

DELIMITER $$
--
-- Procedures
--
DROP PROCEDURE IF EXISTS `usp_Alugueis`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_Alugueis` ()  BEGIN
	SELECT codigo, cod_quarto, valor, dataChegada, dataSaida FROM aluguel;
END$$

DROP PROCEDURE IF EXISTS `usp_AluguelAlterar`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AluguelAlterar` (`aCodigo` INT, `aCodQuarto` INT, `aValor` DECIMAL(10,2), `aDataChegada` DATETIME, `aDataSaida` DATETIME)  BEGIN
	UPDATE aluguel SET cod_quarto = aCodQuarto, valor = aValor, dataChegada = aDataChegada, dataSaida = aDataSaida WHERE codigo = aCodigo;
END$$

DROP PROCEDURE IF EXISTS `usp_AluguelCliente`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AluguelCliente` (`aCodAluguel` INT)  BEGIN
	SELECT codigo, cod_aluguel, contato, cpf, rg, nome FROM cliente WHERE cod_aluguel = aCodAluguel ;
END$$

DROP PROCEDURE IF EXISTS `usp_AluguelExcluir`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AluguelExcluir` (`aCodigo` INT)  BEGIN
	DELETE FROM aluguel WHERE codigo = aCodigo;
END$$

DROP PROCEDURE IF EXISTS `usp_AluguelNovo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AluguelNovo` (`aCodQuarto` INT, `aValor` DECIMAL(10,2), `aDataChegada` DATETIME)  BEGIN
	INSERT INTO aluguel(cod_quarto, valor, dataChegada) VALUES (aCodQuarto, aValor, aDataChegada);
END$$

DROP PROCEDURE IF EXISTS `usp_AluguelPagamento`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AluguelPagamento` (`aCodAluguel` INT)  BEGIN
	SELECT codigo, cod_aluguel, dataPagamento, tipo, valor FROM pagamento WHERE cod_aluguel = aCodAluguel ;
END$$

DROP PROCEDURE IF EXISTS `usp_AluguelPedido`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AluguelPedido` (`aCodAluguel` INT)  BEGIN
	SELECT codigo, cod_aluguel, datapedido FROM pedido WHERE cod_aluguel = aCodAluguel ;
END$$

DROP PROCEDURE IF EXISTS `usp_AluguelQuarto`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AluguelQuarto` ()  BEGIN
	SELECT codigo, cod_quarto, valor, dataChegada, dataSaida FROM aluguel WHERE dataSaida IS NULL;
END$$

DROP PROCEDURE IF EXISTS `usp_ClienteAlterar`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ClienteAlterar` (`aCodigo` INT, `aCodAluguel` INT, `aNome` VARCHAR(40), `aRg` VARCHAR(20), `aCpf` VARCHAR(20), `aContato` VARCHAR(15))  BEGIN
	UPDATE cliente SET cod_aluguel = aCodAluguel, nome = aNome, rg = aRg, cpf = aCpf, contato = aContato WHERE codigo = aCodigo;
END$$

DROP PROCEDURE IF EXISTS `usp_ClienteExcluir`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ClienteExcluir` (`aCodigo` INT)  BEGIN
	DELETE FROM cliente WHERE codigo = aCodigo;
END$$

DROP PROCEDURE IF EXISTS `usp_ClienteNovo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ClienteNovo` (`aCodAluguel` INT, `aNome` VARCHAR(40), `aRg` VARCHAR(20), `aCpf` VARCHAR(20), `aContato` VARCHAR(15))  BEGIN
	INSERT INTO cliente(cod_aluguel, nome, rg, cpf, contato) VALUES (aCodAluguel, aNome, aRg, aCpf, aContato);
END$$

DROP PROCEDURE IF EXISTS `usp_Clientes`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_Clientes` ()  BEGIN
	SELECT codigo, cod_aluguel, nome, rg, cpf, contato FROM cliente;
END$$

DROP PROCEDURE IF EXISTS `usp_LimpezaAlterar`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_LimpezaAlterar` (`aCodigo` INT, `aCodQuarto` INT, `aDataLimpeza` DATETIME)  BEGIN
	UPDATE limpeza SET cod_quarto = aCodQuarto, datalimpeza = aDataLimpeza WHERE codigo = aCodigo;
END$$

DROP PROCEDURE IF EXISTS `usp_LimpezaExcluir`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_LimpezaExcluir` (`aCodigo` INT)  BEGIN
	DELETE FROM limpeza WHERE codigo = aCodigo;
END$$

DROP PROCEDURE IF EXISTS `usp_LimpezaNovo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_LimpezaNovo` (`aCodQuarto` INT, `aDataLimpeza` DATETIME)  BEGIN
	INSERT INTO limpeza(cod_quarto, datalimpeza) VALUES (aCodQuarto, aDataLimpeza);
END$$

DROP PROCEDURE IF EXISTS `usp_Limpezas`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_Limpezas` ()  BEGIN
	SELECT codigo, cod_quarto, datalimpeza FROM limpeza;
END$$

DROP PROCEDURE IF EXISTS `usp_PagamentoAlterar`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_PagamentoAlterar` (`aCodigo` INT, `aCodCliente` INT, `aTipo` VARCHAR(10), `aDataPagamento` DATETIME, `aValor` DECIMAL(10,2))  BEGIN
	UPDATE pagamento SET cod_cliente = aCodCliente, tipo = aTipo, dataPagamento = aDataPagamento, valor = aValor WHERE codigo = aCodigo;
END$$

DROP PROCEDURE IF EXISTS `usp_PagamentoExcluir`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_PagamentoExcluir` (`aCodigo` INT)  BEGIN
	DELETE FROM pagamento WHERE codigo = aCodigo;
END$$

DROP PROCEDURE IF EXISTS `usp_PagamentoNovo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_PagamentoNovo` (`aCodCliente` INT, `aTipo` VARCHAR(10), `aDataPagamento` DATETIME, `aValor` DECIMAL(10,2))  BEGIN
	INSERT INTO pagamento(cod_cliente, tipo, dataPagamento, valor) VALUES (aCodCliente, aTipo, aDataPagamento, aValor);
END$$

DROP PROCEDURE IF EXISTS `usp_Pagamentos`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_Pagamentos` ()  BEGIN
	SELECT codigo, cod_cliente, tipo, dataPagamento, valor FROM pagamento;
END$$

DROP PROCEDURE IF EXISTS `usp_PedidoItemPedido`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_PedidoItemPedido` (`aCodPedido` INT)  BEGIN
	SELECT codigo, cod_pedido, cod_produto, qtde, valor FROM itempedido WHERE cod_pedido = aCodPedido ;
END$$

DROP PROCEDURE IF EXISTS `usp_ProdutoItemPedido`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_ProdutoItemPedido` (`aCodProduto` INT)  BEGIN
    SELECT DISTINCT P.codigo, P.nome, P.qtdeAtual, P.valor FROM produto P INNER JOIN itempedido I WHERE P.codigo = I.cod_produto AND I.cod_produto = aCodProduto;
END$$

DROP PROCEDURE IF EXISTS `usp_QuartoAlterar`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_QuartoAlterar` (`aNumero` INT, `aValorDiaria` DECIMAL(10,2), `aLocalidade` VARCHAR(20))  BEGIN
	UPDATE quarto SET valorDiaria = aValorDiaria, localidade = aLocalidade WHERE numero = aNumero;
END$$

DROP PROCEDURE IF EXISTS `usp_QuartoExcluir`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_QuartoExcluir` (`aNumero` INT)  BEGIN
	DELETE FROM quarto WHERE numero = aNumero;
END$$

DROP PROCEDURE IF EXISTS `usp_QuartoLimpezas`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_QuartoLimpezas` (`aCodQuarto` INT)  BEGIN
	SELECT codigo, cod_quarto, datalimpeza FROM limpeza WHERE cod_quarto = aCodQuarto;
END$$

DROP PROCEDURE IF EXISTS `usp_QuartoNovo`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_QuartoNovo` (`aNumero` INT, `aValorDiaria` DECIMAL(10,2), `aLocalidade` VARCHAR(20))  BEGIN
	INSERT INTO quarto(numero, valorDiaria, localidade) VALUES (aNumero, aValorDiaria, aLocalidade);
END$$

DROP PROCEDURE IF EXISTS `usp_Quartos`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_Quartos` ()  BEGIN
	SELECT numero, valorDiaria, localidade FROM quarto;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aluguel`
--

DROP TABLE IF EXISTS `aluguel`;
CREATE TABLE IF NOT EXISTS `aluguel` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `cod_quarto` int(11) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `dataChegada` datetime NOT NULL,
  `dataSaida` datetime DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `fk_quarto` (`cod_quarto`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `aluguel`
--

INSERT INTO `aluguel` (`codigo`, `cod_quarto`, `valor`, `dataChegada`, `dataSaida`) VALUES
(1, 20, '80.00', '2018-09-16 21:00:00', '2018-09-19 18:00:00'),
(2, 20, '80.00', '2018-09-19 21:00:00', NULL),
(3, 11, '102.00', '2018-09-15 19:00:00', NULL),
(4, 10, '150.00', '2018-08-12 20:00:00', NULL),
(5, 12, '98.00', '2018-08-15 02:00:00', NULL);

-- --------------------------------------------------------

--
-- Estrutura da tabela `cliente`
--

DROP TABLE IF EXISTS `cliente`;
CREATE TABLE IF NOT EXISTS `cliente` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `cod_aluguel` int(11) NOT NULL,
  `nome` varchar(40) NOT NULL,
  `rg` varchar(20) DEFAULT NULL,
  `cpf` varchar(20) DEFAULT NULL,
  `contato` varchar(15) DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `fk_aluguel` (`cod_aluguel`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `cliente`
--

INSERT INTO `cliente` (`codigo`, `cod_aluguel`, `nome`, `rg`, `cpf`, `contato`) VALUES
(1, 1, 'Marcio', '11111111', '222222', '1125212225'),
(2, 1, 'Roberta', '33333333', '2222222', '1132323223'),
(3, 2, 'Rafael', '121212121', '1020102', '152221222'),
(4, 3, 'Leandro', '120220000', '12121212121', '1198556332'),
(5, 4, 'João', '121212112', '10101010', '1198552325'),
(6, 5, 'Hugo', '10101010', '11122222', '1198985665');

-- --------------------------------------------------------

--
-- Estrutura da tabela `entrada`
--

DROP TABLE IF EXISTS `entrada`;
CREATE TABLE IF NOT EXISTS `entrada` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `cod_produto` int(11) NOT NULL,
  `dataEntrada` date NOT NULL,
  `dataVencimento` date NOT NULL,
  `qtde` int(11) NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `fk_produto` (`cod_produto`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `entrada`
--

INSERT INTO `entrada` (`codigo`, `cod_produto`, `dataEntrada`, `dataVencimento`, `qtde`) VALUES
(1, 1, '2018-09-15', '2019-09-15', 20),
(2, 3, '2018-08-11', '2019-08-11', 20),
(3, 3, '2018-08-15', '2019-08-15', 10),
(4, 1, '2018-09-16', '2019-09-16', 30),
(5, 2, '2018-08-14', '2018-09-14', 20);

-- --------------------------------------------------------

--
-- Estrutura da tabela `itempedido`
--

DROP TABLE IF EXISTS `itempedido`;
CREATE TABLE IF NOT EXISTS `itempedido` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `cod_pedido` int(11) NOT NULL,
  `cod_produto` int(11) NOT NULL,
  `qtde` int(11) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `fk_pedido` (`cod_pedido`),
  KEY `fk_produto` (`cod_produto`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `itempedido`
--

INSERT INTO `itempedido` (`codigo`, `cod_pedido`, `cod_produto`, `qtde`, `valor`) VALUES
(1, 1, 1, 2, '6.00'),
(2, 1, 1, 1, '6.00'),
(3, 1, 2, 1, '5.50'),
(4, 2, 3, 1, '13.00'),
(5, 3, 2, 3, '15.50'),
(6, 4, 4, 1, '22.00'),
(7, 5, 5, 1, '15.00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `limpeza`
--

DROP TABLE IF EXISTS `limpeza`;
CREATE TABLE IF NOT EXISTS `limpeza` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `cod_quarto` int(11) NOT NULL,
  `datalimpeza` datetime NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `fk_quarto` (`cod_quarto`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `limpeza`
--

INSERT INTO `limpeza` (`codigo`, `cod_quarto`, `datalimpeza`) VALUES
(1, 20, '2018-09-16 16:00:00'),
(2, 21, '2018-09-17 19:00:00'),
(3, 20, '2018-08-14 19:30:00'),
(4, 10, '2018-08-12 20:00:00'),
(5, 20, '2018-08-19 20:00:00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `pagamento`
--

DROP TABLE IF EXISTS `pagamento`;
CREATE TABLE IF NOT EXISTS `pagamento` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `cod_aluguel` int(11) NOT NULL,
  `tipo` varchar(10) NOT NULL,
  `dataPagamento` datetime NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `fk_aluguel` (`cod_aluguel`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `pagamento`
--

INSERT INTO `pagamento` (`codigo`, `cod_aluguel`, `tipo`, `dataPagamento`, `valor`) VALUES
(1, 1, 'Crédito', '2018-09-19 20:00:00', '120.00'),
(2, 1, 'Dinheiro', '2018-09-19 20:00:00', '100.00'),
(3, 1, 'Dinheiro', '2018-09-19 20:03:00', '136.50'),
(4, 2, 'Dinheiro', '2018-09-19 21:00:00', '80.00'),
(5, 3, 'Cartão', '2018-09-15 22:00:00', '50.00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `pedido`
--

DROP TABLE IF EXISTS `pedido`;
CREATE TABLE IF NOT EXISTS `pedido` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `cod_aluguel` int(11) NOT NULL,
  `datapedido` datetime NOT NULL,
  PRIMARY KEY (`codigo`),
  KEY `fk_aluguel` (`cod_aluguel`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `pedido`
--

INSERT INTO `pedido` (`codigo`, `cod_aluguel`, `datapedido`) VALUES
(1, 1, '2018-09-16 20:00:00'),
(2, 1, '2018-09-16 22:00:00'),
(3, 2, '2018-09-19 23:00:00'),
(4, 4, '2018-08-13 22:00:00'),
(5, 3, '2018-09-15 20:00:00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto`
--

DROP TABLE IF EXISTS `produto`;
CREATE TABLE IF NOT EXISTS `produto` (
  `codigo` int(11) NOT NULL,
  `nome` varchar(30) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `qtdeAtual` int(11) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `produto`
--

INSERT INTO `produto` (`codigo`, `nome`, `valor`, `qtdeAtual`) VALUES
(1, 'Cerveja Lata', '6.00', 20),
(2, 'Suco', '5.50', 10),
(3, 'Cerveja Garrafa', '13.00', 30),
(4, 'Lanche da Manhã', '22.00', NULL),
(5, 'Almoço', '15.00', NULL);

-- --------------------------------------------------------

--
-- Estrutura da tabela `quarto`
--

DROP TABLE IF EXISTS `quarto`;
CREATE TABLE IF NOT EXISTS `quarto` (
  `numero` int(11) NOT NULL,
  `valorDiaria` decimal(10,2) NOT NULL,
  `localidade` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`numero`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Extraindo dados da tabela `quarto`
--

INSERT INTO `quarto` (`numero`, `valorDiaria`, `localidade`) VALUES
(20, '80.00', '2º Andar'),
(21, '98.00', '3º Andar'),
(10, '85.00', 'Térreo'),
(11, '102.00', 'Térreo'),
(12, '98.00', '1º Andar'),
(40, '80.00', 'Térreo'),
(1, '75.00', '2º Andar'),
(2, '90.00', '3º Andar'),
(3, '85.00', 'Térreo'),
(4, '100.00', 'Térreo'),
(5, '90.00', '1º Andar'),
(6, '78.00', '2º Andar'),
(7, '88.00', '3º Andar'),
(8, '85.00', 'Térreo'),
(9, '100.00', 'Térreo'),
(13, '90.00', '1º Andar'),
(14, '80.00', '2º Andar'),
(15, '98.00', '3º Andar'),
(16, '88.00', 'Térreo'),
(17, '100.00', 'Térreo'),
(18, '90.00', '1º Andar'),
(19, '89.00', '2º Andar'),
(22, '100.00', '3º Andar'),
(23, '105.00', 'Térreo'),
(24, '100.00', 'Térreo'),
(25, '96.00', '1º Andar'),
(26, '80.00', '2º Andar'),
(27, '98.00', '3º Andar'),
(28, '85.00', 'Térreo'),
(29, '100.00', 'Térreo'),
(30, '99.00', '1º Andar'),
(31, '89.00', '2º Andar'),
(32, '98.00', '3º Andar'),
(33, '85.00', 'Térreo'),
(34, '99.00', 'Térreo'),
(35, '97.00', '1º Andar'),
(36, '84.00', '2º Andar'),
(37, '91.00', '3º Andar'),
(38, '80.00', 'Térreo'),
(39, '110.00', 'Térreo'),
(41, '92.00', '1º Andar'),
(42, '98.00', '2º Andar'),
(43, '98.00', '3º Andar'),
(44, '85.00', 'Térreo'),
(45, '100.00', 'Térreo');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
