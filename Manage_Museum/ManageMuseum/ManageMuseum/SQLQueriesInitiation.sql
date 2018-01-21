Insert INTO ROLES(Name) VALUES ('spacemanager');
Insert INTO ROLES(Name) VALUES ('artpiecemanager');

Insert INTO USERACCOUNTS(FirstName,LastName,Username,Password,Role_Id) VALUES ('Jessica','Franco','jsfranco','igualparatodos','1');
Insert INTO USERACCOUNTS(FirstName,LastName,Username,Password,Role_Id) VALUES ('Tiago','Gouveia','jtmg','igualparatodos','2');
Insert INTO USERACCOUNTS(FirstName,LastName,Username,Password,Role_Id) VALUES ('Andre','Figueira','ffigueira','igualparatodos','2');

Insert INTO EVENTTYPES(Name) VALUES ('exposicao');
Insert INTO EVENTTYPES(Name) VALUES ('social');

Insert INTO EVENTSTATES(Name) VALUES ('poraprovar');
Insert INTO EVENTSTATES(Name) VALUES ('exibicao');
Insert INTO EVENTSTATES(Name) VALUES ('encerrado');

Insert INTO EVENTS(StartDate,EnDate, Description,Name, EventType_Id, EventState_Id, UserAccount_Id) VALUES ('2018-03-03 00:00:00.000','2018-02-04 00:00:00.000','Isto é uma descrição de evento','Palavras Solarentas','1','1','2');
Insert INTO EVENTS(StartDate,EnDate, Description,Name, EventType_Id, EventState_Id, UserAccount_Id) VALUES ('2018-03-01 00:00:00.000','2018-03-01 00:00:00.000','Isto é uma descrição de evento','Aniversário FNAC','2','1','3');
Insert INTO EVENTS(StartDate,EnDate, Description,Name, EventType_Id, EventState_Id, UserAccount_Id) VALUES ('2018-01-18 00:00:00.000','2018-03-18 00:00:00.000','Isto é uma descrição de evento','Feira da Maxmat','1','2','3');
Insert INTO EVENTS(StartDate,EnDate, Description,Name, EventType_Id, EventState_Id, UserAccount_Id) VALUES ('2018-01-03 00:00:00.000','2018-02-04 00:00:00.000','Isto é uma descrição de evento','Encontro de Universitarios','2','2','2');
Insert INTO EVENTS(StartDate,EnDate, Description,Name, EventType_Id, EventState_Id, UserAccount_Id) VALUES ('2018-02-03 00:00:00.000','2018-02-04 00:00:00.000','Isto é uma descrição de evento','Segunda Guerra Mundial','1','3','2');
Insert INTO EVENTS(StartDate,EnDate, Description,Name, EventType_Id, EventState_Id, UserAccount_Id) VALUES ('2017-12-03 00:00:00.000','2017-01-01 00:00:00.000','Isto é uma descrição de evento','Concerto do Panda','2','3','3');

Insert INTO ROOMMUSEUMS(Area,Floor,Event_Id,Name) VALUES ('4000','1','1','Sala Funchal');
Insert INTO ROOMMUSEUMS(Area,Floor,Event_Id,Name) VALUES ('2700','1','1','Sala Câmara de Lobos');
Insert INTO ROOMMUSEUMS(Area,Floor,Event_Id,Name) VALUES ('3500','1','2','sala Ribeira Brava');
Insert INTO ROOMMUSEUMS(Area,Floor,Event_Id,Name) VALUES ('4000','2','2','Sala Ponta de Sol');
Insert INTO ROOMMUSEUMS(Area,Floor,Event_Id,Name) VALUES ('2700','2','3','Sala Calheta');
Insert INTO ROOMMUSEUMS(Area,Floor,Event_Id,Name) VALUES ('3500','2','3','sala Porto Moniz');
Insert INTO ROOMMUSEUMS(Area,Floor,Event_Id,Name) VALUES ('4000','1','4','Sala São Vicente');
Insert INTO ROOMMUSEUMS(Area,Floor,Event_Id,Name) VALUES ('2700','1','4','Sala Santana');
Insert INTO ROOMMUSEUMS(Area,Floor,Event_Id,Name) VALUES ('3500','1','5','sala Machico');
Insert INTO ROOMMUSEUMS(Area,Floor,Event_Id,Name) VALUES ('4000','2','5','Sala Santa Cruz');
Insert INTO ROOMMUSEUMS(Area,Floor,Event_Id,Name) VALUES ('2700','2','6','Sala Porto Santo');
Insert INTO ROOMMUSEUMS(Area,Floor,Event_Id,Name) VALUES ('3500','2','6','sala Desertas');

Insert INTO OUTSIDESPACES(Event_Id) VALUES ('2');

Insert INTO ARTPIECESTATES(Name) VALUES ('armazem');
Insert INTO ARTPIECESTATES(Name) VALUES ('exposicao');

Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('Grito','É o homem bem no fundo, de cartola e paletó preto, virando-se ligeiramente de costas, como se olhasse de soslaio. Dá até para ver a barba castanha arruivada.','250','1','2016-02-04 00:00:00.000','Carlos','2');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('MonaLisa','...um quadro descrito por Huysmans como ‘uma caverna iluminada por pedras preciosas como um tabernáculo, contendo aquela inimitável e radiante joia, o corpo branco, seus seios e lábios tintos de rosa, Galateia, adormecida...’','40','1','1986-02-04 00:00:00.000','Pedro','2');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('MarianaChagasFreitas','O almoço dos remadores. Mostra uma arde agradavelmente ostentatória na Maison Fournaise, um restaurante à beira do Sena em um dos lugares então na moda entre os parisienses, aonde eles iam a passeio, geralmente de trem. Barcos de passeio e um esquife podem ser vistos por entre os salgueiros cinzentos e prateados. Um toldo listrado de vermelho e branco protege o grupo do sol. ','200','1','1995-02-04 00:00:00.000','Mariana','2');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('Sapato','...um retrato incrivelmente adocicado das meninas mais novas, Alice e Elisabeth. As duas meninas têm o cabelo da mãe (loiro arruivado).','30','2','1982-02-04 00:00:00.000','Marco','2');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('Interlocking Circles','Sob este aspecto, pode sempre considerar-se este auto-retrato','300','2','1981-02-04 00:00:00.000','Nadir Afonso','2');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('Ilha dos Amores','Odette recebendo Swann, vestida em seu quimono em sua sala de almofadas de seda japonesas, biombos e lanternas, impregnada do aroma forte dos crisântemos, como um japonisme olfativo.','30','2','1976-02-04 00:00:00.000','António Soares','1');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('Ilustração da nota de 100 escudos','Greuze mostra a mão de um velho marido segurando a da sua jovem mulher, como se este contacto o tranquilizasse na confiança e na certeza, no momento em que nós vemos os dois jovens trair e, talvez em breve, serem eles mesmos traídos pela queda da bilha?','88','1','2017-02-04 00:00:00.000','José de Guimarães','1');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('Mapa de Portugal de 1561','No Auto-retrato com lunetas (óculos sem hastes, talvez lunetas de trabalho), Chardin deixa-se ver ou 35 faz-se observar de perfil, parece mais activo, talvez interrompido por um instante, e desviando os olhos do quadro. Mas é em vias de pintar ou de desenhar,','291','1','1975-02-04 00:00:00.000','Luís Filipe de Abreu','1');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('Pianista','No provocante retrato que Monet faz da esposa, Camille, ela usa uma peruca dourada e um vestido vermelho no qual há bordado um samurai sacando sua espada. Atrás dela há ventarolas espalhadas pela parede e pelo chão, como a explosão dos fogos de artifício de Whistler.','147','3','1972-02-04 00:00:00.000','Fernando Álvaro Seco','2');





