#comentário;
#control + t = cria abas
#control + tab = navega nas abas
#control + shift + tab = faz a navegação ao contrária

select id,
		nome,
		datanascimento,
        idade,
        status
from pessoa
order by nome
;

select  id,
		id_pessoa,
		login,
		senha,
        status
from usuario;

SELECT p.id as codigo_pessoa,
		u.id as codigo_usuario,
        p.nome,
        p.datanascimento as nascimento,
        p.idade,
        p.status as situacao_pessoa,
        u.login,
        u.senha,
        u.status as situacao_usuario
FROM pessoa as p 
JOIN usuario as u 
	ON (p.id = u.id_pessoa)
;


#ele ta dizendo que vai selecionar tudo essas coisas das duas tabelas 
#e vai juntar em uma só onde o id da pessoa for igual ao
#id do usuario

SELECT * FROM pessoa WHERE datanascimento < '2007-01-01';

SELECT p2.id FROM pessoa as p2 order by id desc limit 1;

#limit diz quantas linhas devem ser retornadas
#desc ordena decrescente
