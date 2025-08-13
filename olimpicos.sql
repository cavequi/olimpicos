create database dbolimpicos;
use dbolimpicos;

create table modalidades (
	cod_modalidade int primary key auto_increment,
    nome_modalidade varchar(50)
);

insert into modalidades (nome_modalidade) values
('Atletismo'),('Natação'),('Vôlei de Quadra'),('Vôlei de Praia');

create table provas (
	cod_prova int primary key auto_increment,
    nome_prova varchar(100),
    cod_modalidade int,
    foreign key (cod_modalidade) references modalidades (cod_modalidade) 
);

insert into provas (nome_prova, cod_modalidade) values
('10000m Feminino', 1);

INSERT INTO provas (nome_prova, cod_modalidade) VALUES
('10000m Masculino', 1),
('100m Feminino', 1),
('100m Masculino', 1),
('100m com barreiras Feminino', 1),
('110m com Barreiras Masculino', 1),
('1500m Masculino', 1),
('200m Feminino', 1),
('200m Masculino', 1),
('20km Marcha Atlética Feminina', 1),
('20km Marcha Atlética Masculino', 1),
('3000m com Obstáculos Feminino', 1),
('3000m com Obstáculos Masculino', 1),
('400m Feminino', 1),
('400m Feminino Feminino', 1),
('400m Masculino', 1),
('400m com Barreiras Feminina', 1),
('400m com Barreiras Feminino', 1),
('400m com Barreiras Masculino', 1),
('5000m Feminino', 1),
('5000m Masculino', 1),
('50km Marcha Atlética', 1),
('60m Masculino', 1),
('800m Feminino', 1),
('800m Masculino', 1),
('80m com Barreiras Feminino', 1),
('Arremesso de Peso Feminino', 1),
('Arremesso de Peso Masculino', 1),
('Arremesso do Peso Masculino', 1),
('Cross Country Masculino', 1),
('Decatlon', 1),
('Decatlon Masculino', 1),
('Heptatlo Feminino', 1),
('Lançamento de Dardo Feminino', 1),
('Lançamento de Dardo Masculino', 1),
('Lançamento de Disco Feminino', 1),
('Lançamento de Disco Masculino', 1),
('Lançamento do Dardo', 1),
('Lançamento do Dardo Feminino', 1),
('Lançamento do Disco Feminino', 1),
('Lançamento do Disco Masculino', 1),
('Lançamento do Martelo Masculino', 1),
('Maratona Feminina', 1),
('Maratona Masculina', 1),
('Marcha Atletica Masculina 20km', 1),
('Marcha Atlética 20 Km Feminino', 1),
('Marcha Atlética 20 Km Masculino', 1),
('Marcha Atlética 50 Km Masculino', 1),
('Marcha Atlética Feminino 20km', 1),
('Pentatlo Feminino', 1),
('Revezamento 4 x 100m Feminino', 1),
('Revezamento 4 x 100m Masculino', 1),
('Revezamento 4 x 400 Masculino', 1),
('Revezamento 4 x 400m Feminino', 1),
('Revezamento 4 x 400m Masculino', 1),
('Revezamento 4 x 400m Misto', 1),
('Revezamento Marcha Atlética Misto', 1),
('Revezametno 4 x 400m Masculino', 1),
('Salto Triplo Feminino', 1),
('Salto Triplo Masculino', 1),
('Salto com Vara Feminino', 1),
('Salto com Vara Masculino', 1),
('Salto em Altura Feminino', 1),
('Salto em Altura Masculino', 1),
('Salto em Distância Feminino', 1),
('Salto em Distância Masculino', 1);

INSERT INTO provas (nome_prova, cod_modalidade) VALUES
('100m Borboleta Feminino', 2),
('100m Borboleta Masculino', 2),
('100m Costas Feminino', 2),
('100m Costas Masculino', 2),
('100m Livre Feminino', 2),
('100m Livre Masculino', 2),
('100m Nado Livre Masculino', 2),
('100m Peito Feminino', 2),
('100m Peito Masculino', 2),
('1500m Livre Feminino', 2),
('1500m Livre Masculino', 2),
('1500m Nado Livre', 2),
('200m Borboleta Feminino', 2),
('200m Borboleta Masculino', 2),
('200m Costas Masculino', 2),
('200m Livre Feminino', 2),
('200m Livre Masculino', 2),
('200m Medley Feminino', 2),
('200m Medley Masculino', 2),
('200m Nado Livre', 2),
('200m Nado Livre Masculino', 2),
('200m Peito Feminino', 2),
('200m Peito Masculino', 2),
('400m Livre Feminino', 2),
('400m Livre Masculino', 2),
('400m Medley Feminino', 2),
('400m Medley Masculino', 2),
('400m Nado Livre Feminino', 2),
('400m Nado Livre Masculino', 2),
('50m Livre Feminino', 2),
('50m Livre Masculino', 2),
('800m Livre Feminino', 2),
('800m Livre Masculino', 2),
('800m Nado Livre Feminino', 2),
('800m Nado Livre Natação', 2),
('Mixed 4 x 100m Medley Relay', 2),
('Revezamento 4 x 100m Nado Livre Masculino', 2),
('Revezamento 4 x 200m Nado Livre Masculino', 2),
('Revezamento 4x100m Livre Feminino', 2),
('Revezamento 4x100m Livre Masculino', 2),
('Revezamento 4x100m Medley Feminino', 2),
('Revezamento 4x100m Medley Masculino', 2),
('Revezamento 4x100m Medley Misto', 2),
('Revezamento 4x100m Nado Livre Feminino', 2),
('Revezamento 4x200m Livre Feminino', 2),
('Revezamento 4x200m Livre Masculino', 2),
('Revezamento 4x200m Nado Livre Feminino', 2);

insert into provas (nome_prova, cod_modalidade) values
('Masculino', 3),
('Feminino', 3);

insert into provas (nome_prova, cod_modalidade) values
('Masculino', 4),
('Feminino', 4);

select modalidades.nome_modalidade , provas.nome_prova
from provas , modalidades                   	 	
where modalidades.cod_modalidade = provas.cod_modalidade; 	     

CREATE TABLE estados (
  cod_estado int primary key auto_increment,
  nome_estado varchar(255) NOT NULL
);

create table cidades(
cod_cidade int primary key auto_increment,
nome_cidade varchar(255) NOT NULL,
cod_estado int
);

INSERT INTO estados (nome_estado) VALUES
('Acre'),
('Alagoas'),
('Alemanha'),
('Amapá'),
('Amazonas'),
('Argentina'),
('Armênia'),
('Austrália'),
('Bahia'),
('Bielorussia'),
('Bélgica'),
('Ceará'),
('China'),
('Colômbia'),
('Croácia'),
('Cuba'),
('Distrito Federal'),
('EUA'),
('Espanha'),
('Espírito Santo'),
('França'),
('Goiás'),
('Grã-Bretanha'),
('Holanda'),
('Hungria'),
('Inglaterra'),
('Itália'),
('Japão'),
('Lituânia'),
('Maranhão'),
('Mato Grosso'),
('Mato Grosso do Sul'),
('Minas Gerais'),
('Paraná'),
('Paraíba'),
('Pará'),
('Pernambuco'),
('Piauí'),
('Polônia'),
('Portugal'),
('Rio Grande do Norte'),
('Rio Grande do Sul'),
('Rio de Janeiro'),
('Rondônia'),
('Roraima'),
('Santa Catarina'),
('Sergipe'),
('Suiça'),
('Suécia'),
('São Paulo'),
('Sérvia'),
('Uruguai'),
('nan');

insert into cidades (nome_cidade, cod_estado) values
('?', 50),
('Adamantina', 50),
('Aguaí', 50),
('Americana', 50),
('Amparo', 50),
('Andradina', 50),
('Araraquara', 50),
('Araras', 50),
('Araçatuba', 50),
('Artur Nogueira', 50),
('Arujá', 50),
('Atibaia', 50),
('BASTOS', 50),
('Barra Bonita', 50),
('Barueri', 50),
('Bauru', 50),
('Boa Esperança do Sul', 50),
('Botucatu', 50),
('Brasília', 50),
('CAMPINAS', 50),
('Caieiras', 50),
('Campinas', 50),
('Campo Limpo Paulista', 50),
('Campos do Jordão', 50),
('Capivari', 50),
('Capão Bonito', 50),
('Caraguatatuba', 50),
('Carapicuíba', 50),
('Casa Branca', 50),
('Catanduva', 50),
('Colina', 50),
('Conchal', 50),
('Coronel Macedo', 50),
('Cosmopólis', 50),
('Cotia', 50),
('Cruzeiro', 50),
('Cubatão', 50),
('Descalvado', 50),
('Diadema', 50),
('Dracena', 50),
('Ferraz de Vasconcelos', 50),
('Franca', 50),
('Garça', 50),
('Guararapes', 50),
('Guaratinguetá', 50),
('Guarujá', 50),
('Guarulhos', 50),
('Guaíra', 50),
('ITARIRI', 50),
('ITU', 50),
('Ibirá', 50),
('Ibitinga', 50),
('Iguape', 50),
('Ilha Solteira', 50),
('Ilhabela', 50),
('Indiaporã', 50),
('Ipaussu', 50),
('Itanhaém', 50),
('Itapeva', 50),
('Itatiba', 50),
('Itu', 50),
('Ituverava', 50),
('Jacareí', 50),
('Jandira', 50),
('Jaú', 50),
('Jundiaí', 50),
('Juquiá', 50),
('Leme', 50),
('Lençóis Paulista', 50),
('Limeira', 50),
('Lins', 50),
('Lorena', 50),
('Lucélia', 50),
('Marília', 50),
('Matão', 50),
('Mauá', 50),
('Mococa', 50),
('Mogi das Cruzes', 50),
('Morungaba', 50),
('Nova Odessa', 50),
('Orlândia', 50),
('Osasco', 50),
('Osvaldo Cruz', 50),
('Pacaembu', 50),
('Paraguaçu Paulista', 50),
('Parapuã', 50),
('Pariquera-Açu', 50),
('Patrocinio Paulista', 50),
('Pedregulho', 50),
('Pedro de Toledo', 50),
('Penápolis', 50),
('Peruíbe', 50),
('Pindamonhangaba', 50),
('Piracicaba', 50),
('Piraju', 50),
('Pirassununga', 50),
('Porto Ferreira', 50),
('Potirendaba', 50),
('Praia Grande', 50),
('Presidente Prudente', 50),
('Promissão', 50),
('Quintana', 50),
('Registro', 50),
('Ribeirão Preto', 50),
('Rio Claro', 50),
('Rio de Janeiro', 50),
('Rosárial', 50),
('Rubineia', 50),
('Salto', 50),
('Santa Bárbara d Oeste', 50),
('Santa Maria da Serra', 50),
('Santa Rita do Passa Quatro', 50),
('Santo André', 50),
('Santo Antônio de Posse', 50),
('Santos', 50),
('Saudades', 50),
('Sertãozinho', 50),
('Sorocaba', 50),
('Sumaré', 50),
('Suzano', 50),
('São Bernardo do Campo', 50),
('São Caetano do Sul', 50),
('São Carlos', 50),
('São Joaquim da Barra', 50),
('São José do Rio Preto', 50),
('São José dos Campos', 50),
('São João da Boa Vista', 50),
('São Manuel', 50),
('São Paulo', 50),
('São Roque', 50),
('São Sebastião', 50),
('São Vicente', 50),
('Taubaté', 50),
('Tietê', 50),
('Tupi Paulista', 50),
('Tupã', 50),
('Ubatuba', 50),
('Valinhos', 50),
('Vinhedo', 50),
('Vista Alegre do Alto', 50),
('Votorantim', 50),
('Álvares Machado', 50);

alter table cidades
add constraint fkestado_cidade
foreign key (cod_estado)
references estados (cod_estado);


CREATE TABLE edicao (
  cod_edicao int primary key auto_increment,
  ano int,
  sede varchar(30)
);

CREATE TABLE atletas (
  cod_atleta int primary key auto_increment,
  nome_atleta varchar(255),
  data_nascimento varchar(20),
  sexo char(1),
  altura decimal(5,2) DEFAULT NULL,
  peso decimal(5,2) DEFAULT NULL,
  cod_cidade int
);

CREATE TABLE resultados_atletas (
  cod_atleta_res int primary key auto_increment,
  cod_atleta int,
  cod_prova int,
  edicao int,
  resultado varchar(255) DEFAULT NULL,
  medalha varchar(255) DEFAULT NULL
);

alter table atletas 
add constraint fkatletas_cidade
foreign key (cod_cidade)
references cidades (cod_cidade);

alter table resultados_atletas
add constraint  fkresultado_atletas
foreign key (cod_atleta )
references atletas (cod_atleta),
add constraint  fkresultado_prova
foreign key (cod_prova )
references provas (cod_prova);

alter table resultados_atletas
add constraint  fkresultado_edicao
foreign key (edicao)
references edicao (cod_edicao);

INSERT INTO edicao (ano, sede) VALUES
(1900, 'Paris'),
(1920, 'Antuérpia'),
(1924, 'Paris'),
(1932, 'Los Angeles'),
(1936, 'Berlim'),
(1948, 'Londres'),
(1952, 'Helsinque'),
(1956, 'Melbourne'),
(1960, 'Roma'),
(1964, 'Tóquio'),
(1968, 'Cidade do México'),
(1972, 'Munique'),
(1976, 'Montreal'),
(1980, 'Moscou'),
(1984, 'Los Angeles'),
(1988, 'Seul'),
(1992, 'Barcelona'),
(1996, 'Atlanta'),
(2000, 'Sydney'),
(2004, 'Atenas'),
(2008, 'Pequim'),
(2012, 'Londres'),
(2016, 'Rio de Janeiro'),
(2020, 'Tóquio'),
(2024, 'Paris'),
(2028, 'Los Angeles'),
(2032, 'Brisbane');

INSERT INTO atletas (nome_atleta, data_nascimento, sexo, altura, peso, cod_cidade) VALUES
('Adhemar Ferreira da Silva', '1927-09-29', 'M', NULL, NULL, 129),
('Aderval Luiz Arvani', '1949-01-07', 'M', NULL, NULL, 129),
('Stephanie Balduccini', '2004-09-20', 'F',NULL, NULL, 129),
('Thaissa Barbosa Presti', '1988-04-26', 'F',NULL, NULL, 129),
('Wanda dos Santos', '1932-06-01', 'F', NULL, NULL, 129),
('Manuel dos Santos Filho', '1939-02-22', 'M', NULL, NULL,129),
('Marcelo Teles Negrão', '1972-10-10', 'M', NULL, NULL, 129),
('Fofão', '1970-03-10', 'F', NULL, NULL, 129);

insert into resultados_atletas (cod_atleta ,cod_prova ,edicao , resultado , medalha)
values
(8 , 115 ,  18 , '3º lugar','Bronze'),
(8 , 115 ,  19 , '3º lugar','Bronze'),
(8 , 115 ,  20 , '4º lugar',''),
(8 , 115 ,  21 , '1º lugar','Ouro');

insert into resultados_atletas (cod_atleta ,cod_prova ,edicao , resultado , medalha)
values
(1 , 60 ,  6 , '8º lugar',''),
(1 , 60 ,  7 , '1º lugar','Ouro'),
(1 , 60 ,  8 , '1º lugar','Ouro'),
(1 , 60 ,  9 , '14º lugar','');

insert into resultados_atletas (cod_atleta ,cod_prova ,edicao , resultado , medalha)
values
(3 , 109 ,  24, 'Eliminada na primeira Fase',''),
(3 , 105 ,  24 , 'Eliminada na primeira Fase',''),
(3 , 113 ,  25 , '7º lugar',''),
(3 , 102 ,  25 , 'Eliminada nas preliminares',''),
(3 , 110 ,  25 , 'Eliminada nas preliminares','');

INSERT INTO atletas (nome_atleta, data_nascimento, sexo, altura, peso, cod_cidade) VALUES
('Rebeca Andrade ', '1999-05-08', 'F', 1.51, 46 , 47);

insert into modalidades (nome_modalidade) values
('Ginástica Artística');

insert into provas (nome_prova , cod_modalidade) values
		 
('Argolas Masculino'  , 5),
('Barra Fixa'  , 5),
('Barra Fixa Masculino'  , 5),
('Barras Assimétricas Feminino'  , 5),
('Barras Paralelas Masculino '  , 5),
('Cavalo com Alças Masculino'  , 5),
('Equipes Feminino'  , 5),
('Equipes Masculino'  , 5),
('Individual All-Around Feminino'  , 5),
('Individual All-Around Masculino '  , 5),
('Individual Geral Feminino'  , 5),
('Individual Geral Masculino'  , 5),
('Salto sobre a mesa Feminino'  , 5),
('Salto sobre a mesa Masculino'  , 5),
('Argolas Masculino'  , 5),
('Solo Masculino', 5),
('Trave de Equilibrio Feminino', 5);

insert into provas (nome_prova , cod_modalidade) values
('Solo Feminino', 5);

insert into resultados_atletas (cod_atleta ,cod_prova ,edicao , resultado , medalha)
values
(3 , 126  ,  23 , '11º Lugar',''),
(3 , 124 ,  23 , '8º lugar',''),
(3 ,  132,  23 , 'Não se classificou para as Finais',''),
(3 ,  121,  23 , 'Não se classificou para as Finais',''),
(3 ,  134,  23 , 'Não se classificou para as Finais',''),

(3 ,  121,  24 , 'Não se classificou para as Finais',''),
(3 , 130 ,  24 , '1º Lugar','Ouro'),
(3 , 135 ,  24 , '5º Lugar',''),
(3 , 126 ,  24 , '2º Lugar','Prata'),

(3 , 124 ,  25 , '3º Lugar','Bronze'),
(3 ,  128,  25 , '2º Lugar','Prata'),
(3 ,  135 ,  25 , '1º Lugar','Ouro'),
(3 ,  130,  25 , '2º Lugar','Prata'),
(3 , 134 ,  25 , '4º Lugar','');

SELECT 
    a.nome_atleta,
    a.data_nascimento,
    c.nome_cidade AS cidade_nascimento,
    e.nome_estado AS estado_nascimento,
    m.nome_modalidade,
    p.cod_prova,
    ra.resultado,
    ra.medalha,
    ed.ano AS ano_edicao,
    ed.sede
FROM resultados_atletas ra
INNER JOIN atletas a ON ra.cod_atleta = a.cod_atleta
INNER JOIN cidades c ON a.cod_cidade = c.cod_cidade
INNER JOIN estados e ON c.cod_estado = e.cod_estado
INNER JOIN provas p ON ra.cod_prova = p.cod_prova
INNER JOIN modalidades m ON p.cod_modalidade = m.cod_modalidade
INNER JOIN edicao ed ON ra.edicao = ed.cod_edicao;



insert into resultados_atletas (cod_atleta ,cod_prova ,edicao , resultado , medalha)
values
(12 , 115 ,  20, '4° Lugar',''),
(12 , 115 ,  21 , '1° Lugar','Ouro'),
(11 , 115 ,  21 , '1° Lugar','Ouro'),
(11 , 115 ,  22 , '1° Lugar','Ouro'),
(11 , 115 ,  23 , '5° Lugar',''),
(11 , 115 ,  25 , '3° Lugar','Bronze'),
(10 , 115 ,  21 , '1° Lugar','Ouro'),
(10 , 115 ,  22 , '1° Lugar','Ouro'),
(10 , 115 ,  23 , '5° Lugar','');



INSERT INTO atletas (nome_atleta, data_nascimento, sexo, altura, peso, cod_cidade) VALUES
('Fernanda Neves Beling', '1982-12-05', 'F', NULL, NULL, 143);




insert into resultados_atletas (cod_atleta ,cod_prova ,edicao , resultado , medalha)
values
(13 , 137 ,  21, '11° Lugar','');


insert into modalidades (nome_modalidade) values  ('Basquete');


insert into provas (nome_prova , cod_modalidade)  values  ('Masculino', 6),('Feminino', 6);




select * from modalidades;

select * from cidades;

select * from resultados_atletas;

describe provas;