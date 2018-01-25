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
Insert INTO EVENTSTATES(Name) VALUES ('aceites');
Insert INTO EVENTSTATES(Name) VALUES ('rejeitado');


Insert INTO SPACESTATES(Name) VALUES ('livre');
Insert INTO SPACESTATES(Name) VALUES ('ocupada');

Insert INTO ROOMMUSEUMS(SumRoomArtPieces,MaxRoomArtPieces,Floor,Event_Id,Name,SpaceState_Id) VALUES ('0','40','1',null,'Sala Funchal','1');
Insert INTO ROOMMUSEUMS(SumRoomArtPieces,MaxRoomArtPieces,Floor,Event_Id,Name,SpaceState_Id) VALUES ('0','30','1',null,'Sala Câmara de Lobos','1');
Insert INTO ROOMMUSEUMS(SumRoomArtPieces,MaxRoomArtPieces,Floor,Event_Id,Name,SpaceState_Id) VALUES ('0','30','1',null,'sala Ribeira Brava','1');
Insert INTO ROOMMUSEUMS(SumRoomArtPieces,MaxRoomArtPieces,Floor,Event_Id,Name,SpaceState_Id) VALUES ('0','20','2',null,'Sala Ponta de Sol','1');
Insert INTO ROOMMUSEUMS(SumRoomArtPieces,MaxRoomArtPieces,Floor,Event_Id,Name,SpaceState_Id) VALUES ('0','20','2',null,'Sala Calheta','1');
Insert INTO ROOMMUSEUMS(SumRoomArtPieces,MaxRoomArtPieces,Floor,Event_Id,Name,SpaceState_Id) VALUES ('0','25','2',null,'sala Porto Moniz','1');
Insert INTO ROOMMUSEUMS(SumRoomArtPieces,MaxRoomArtPieces,Floor,Event_Id,Name,SpaceState_Id) VALUES ('0','25','1',null,'Sala São Vicente','1');
Insert INTO ROOMMUSEUMS(SumRoomArtPieces,MaxRoomArtPieces,Floor,Event_Id,Name,SpaceState_Id) VALUES ('0','20','1',null,'Sala Santana','1');
Insert INTO ROOMMUSEUMS(SumRoomArtPieces,MaxRoomArtPieces,Floor,Event_Id,Name,SpaceState_Id) VALUES ('0','20','1',null,'sala Machico','1');
Insert INTO ROOMMUSEUMS(SumRoomArtPieces,MaxRoomArtPieces,Floor,Event_Id,Name,SpaceState_Id) VALUES ('0','35','2',null,'Sala Santa Cruz','1');
Insert INTO ROOMMUSEUMS(SumRoomArtPieces,MaxRoomArtPieces,Floor,Event_Id,Name,SpaceState_Id) VALUES ('0','35','2',null,'Sala Porto Santo','1');
Insert INTO ROOMMUSEUMS(SumRoomArtPieces,MaxRoomArtPieces,Floor,Event_Id,Name,SpaceState_Id) VALUES ('0','40','2',null,'sala Desertas','1');

Insert INTO OUTSIDESPACES(Name,Area,SpaceState_Id,Event_Id) VALUES ('Jardim do Labirinto','20000','1',null);
Insert INTO OUTSIDESPACES(Name,Area,SpaceState_Id,Event_Id) VALUES ('Jardim do Pinheiro','7000','1',null);
Insert INTO OUTSIDESPACES(Name,Area,SpaceState_Id,Event_Id) VALUES ('Jardim Laurisilva','14000','1',null);
Insert INTO OUTSIDESPACES(Name,Area,SpaceState_Id,Event_Id) VALUES ('Jardim do Eucalipto','13000','1',null);
Insert INTO OUTSIDESPACES(Name,Area,SpaceState_Id,Event_Id) VALUES ('Jardim do Urzal','10000','1',null);
Insert INTO OUTSIDESPACES(Name,Area,SpaceState_Id,Event_Id) VALUES ('Jardim do Castanheiro','7000','1',null);
Insert INTO OUTSIDESPACES(Name,Area,SpaceState_Id,Event_Id) VALUES ('Jardim das Orquideas','14000','1',null);
Insert INTO OUTSIDESPACES(Name,Area,SpaceState_Id,Event_Id) VALUES ('Jardim do Louro','27000','1',null);


Insert INTO ARTPIECESTATES(Name) VALUES ('armazem');
Insert INTO ARTPIECESTATES(Name) VALUES ('exposicao');

Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('Grito','É o homem bem no fundo, de cartola e paletó preto, virando-se ligeiramente de costas, como se olhasse de soslaio. Dá até para ver a barba castanha arruivada.','250',null,'2016-02-04 00:00:00.000','Carlos','1');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('MonaLisa','...um quadro descrito por Huysmans como ‘uma caverna iluminada por pedras preciosas como um tabernáculo, contendo aquela inimitável e radiante joia, o corpo branco, seus seios e lábios tintos de rosa, Galateia, adormecida...’','40',null,'1986-02-04 00:00:00.000','Pedro','1');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('MarianaChagasFreitas','O almoço dos remadores. Mostra uma arde agradavelmente ostentatória na Maison Fournaise, um restaurante à beira do Sena em um dos lugares então na moda entre os parisienses, aonde eles iam a passeio, geralmente de trem. Barcos de passeio e um esquife podem ser vistos por entre os salgueiros cinzentos e prateados. Um toldo listrado de vermelho e branco protege o grupo do sol. ','200',null,'1995-02-04 00:00:00.000','Mariana','1');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('Sapato','...um retrato incrivelmente adocicado das meninas mais novas, Alice e Elisabeth. As duas meninas têm o cabelo da mãe (loiro arruivado).','30',null,'1982-02-04 00:00:00.000','Marco','1');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('Interlocking Circles','Sob este aspecto, pode sempre considerar-se este auto-retrato','300',null,'1981-02-04 00:00:00.000','Nadir Afonso','1');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('Ilha dos Amores','Odette recebendo Swann, vestida em seu quimono em sua sala de almofadas de seda japonesas, biombos e lanternas, impregnada do aroma forte dos crisântemos, como um japonisme olfativo.','30',null,'1976-02-04 00:00:00.000','António Soares','1');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('Ilustração da nota de 100 escudos','Greuze mostra a mão de um velho marido segurando a da sua jovem mulher, como se este contacto o tranquilizasse na confiança e na certeza, no momento em que nós vemos os dois jovens trair e, talvez em breve, serem eles mesmos traídos pela queda da bilha?','88',null,'2017-02-04 00:00:00.000','José de Guimarães','1');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('Mapa de Portugal de 1561','No Auto-retrato com lunetas (óculos sem hastes, talvez lunetas de trabalho), Chardin deixa-se ver ou 35 faz-se observar de perfil, parece mais activo, talvez interrompido por um instante, e desviando os olhos do quadro. Mas é em vias de pintar ou de desenhar,','291',null,'1975-02-04 00:00:00.000','Luís Filipe de Abreu','1');
Insert INTO ARTPIECES(Name,Description,Dimension,RoomMuseum_id,Year,Author,ArtPieceState_Id) VALUES ('Pianista','No provocante retrato que Monet faz da esposa, Camille, ela usa uma peruca dourada e um vestido vermelho no qual há bordado um samurai sacando sua espada. Atrás dela há ventarolas espalhadas pela parede e pelo chão, como a explosão dos fogos de artifício de Whistler.','147',null,'1972-02-04 00:00:00.000','Fernando Álvaro Seco','1');





