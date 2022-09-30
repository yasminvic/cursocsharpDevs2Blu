INSERT INTO pessoa (nome, 
					datanascimento, 
					idade, 
					status)
VALUES  ('Guria de tal', '1996-05-31', 26, 1)
;

/*DELETE SIMPLES*/

DELETE FROM pessoa 
WHERE id = 7;

/*DELELTE SUBQUERY*/
DELETE FROM pessoa 
WHERE id = (SELECT id FROM pessoa as p2 order by p2.id desc LIMIT 1);

/*DELETE FROM pessoa
WHERE nome like '%de tal';*/

#vai apagar da tabela pessoa onde o nome tiver a string de tal
#esse like é pra pesquisar, por exemplo, todos que comecarem com a letra M ele vai apagar
#esse % quer dizer que vai ignorar o que está na frente