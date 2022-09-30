UPDATE pessoa
	SET datanascimento = '2006-05-31',
		idade = 24
WHERE id IN (1, 2, 3);
#vai mudar a data de nascimento e idade na tabela pessoa onde o id
#estiver dentro desse intervalo

UPDATE pessoa
	SET datanascimento = '2007-05-31',
		idade = 15
WHERE id IN (4, 5);