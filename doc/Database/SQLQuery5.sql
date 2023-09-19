SELECT * FROM [authors] 
SELECT DISTINCT sb_subscriber FROM [subscriptions]

SELECT	s_name, COUNT(*) AS [people_count] FROM [subscribers] GROUP BY s_name
-- показать без повторений идентификаторы книг, которые были взяты читателями
SELECT DISTINCT sb_book FROM [subscriptions]

--показать по каждой книге, которую читатели брали в библиотеке, количество выдач этой книги читателям.
SELECT sb_book, COUNT(*) AS [book_count] FROM [subscriptions] GROUP BY [sb_book]
SELECT COUNT(*) AS [total_book] FROM [books]
--показать, сколько всего читателей зарегистрировано в библиотеке.
SELECT COUNT(*) AS [total_readers] FROM [subscribers]
--показать, сколько всего экземпляров книг выдано читателям.
SELECT COUNT(sb_book) AS [in_use] FROM [subscriptions] WHERE [sb_is_active] = 'Y'
--показать, сколько всего разных книг выдано читателям.
SELECT COUNT(DISTINCT sb_book) AS [in_use] FROM [subscriptions] WHERE [sb_is_active] = 'Y'
--показать, сколько всего раз читателям выдавались книги.
SELECT COUNT([sb_book]) AS [total_n_use] FROM [subscriptions] WHERE [sb_is_active] = 'N'
--показать, сколько читателей брало книги в библиотеке.
SELECT COUNT( DISTINCT [sb_subscriber]) AS [total_readers_take_book] FROM [subscriptions] WHERE [sb_is_active] = 'N'
--показать общее (сумму), минимальное, максимальное и среднее значение количества экземпляров книг в библиотеке.
	SELECT	SUM([b_quantity]) AS [sum],
			MIN([b_quantity]) AS [min],
			MAX([b_quantity]) AS [MAX],
			AVG(CAST([b_quantity] AS FLOAT)) AS [AVG]
	FROM [books]
--показать первую и последнюю даты выдачи книги читателю.
	SELECT MIN([sb_start]) AS [first_date], MAX([sb_start]) AS [last_date] FROM [subscriptions]
--показать все книги в библиотеке в порядке возрастания их года издания.
SELECT [b_name], [b_year] FROM [books] ORDER BY [b_year] ASC
--показать все книги в библиотеке в порядке убывания ихгода издания.
SELECT [b_name], [b_year] FROM [books] ORDER BY [b_year] DESC
--показать список авторов в обратном алфавитном порядке (т.е. «Я → А»).
SELECT [a_name] FROM [authors] ORDER BY [a_name] DESC
--показать книги, изданные в период 1990-2000 годов, представленные в библиотеке в количестве трёх и более экземпляров.
SELECT [b_name], [b_year], [b_quantity] FROM [books] WHERE [b_year] >= 1990 and [b_year] <= 2000 and [b_quantity] >=3
SELECT [b_name], [b_year], [b_quantity] FROM [books] WHERE [b_year] BETWEEN 1990 and 2000 and [b_quantity] >=3
--показать идентификаторы и даты выдачи книг за лето 2012-го года.
SELECT [sb_id], [sb_start] FROM [subscriptions] WHERE [sb_start] >= '2012-06-01' AND [sb_start] < '2012-09-01'
----показать книги, количество экземпляров которых меньше среднего по библиотеке.
--SELECT	[b_name], [b_quantity] FROM [books]
----GROUP BY [b_name], [b_quantity]
--HAVING [b_quantity] <= AVG([b_quantity])
----показать идентификаторы и даты выдачи книг за первый год работы библиотеки (первым годом работы библиотеки считать все даты с 
----первой выдачи книги по 31-е декабря (включительно) того года, когда библиотека начала работать).

-- показать просто одну любую книгу, количество экземпляров которой максимально (равно максимуму по всем книгам).
SELECT TOP 1 [b_name], [b_quantity] FROM [books] ORDER BY [b_quantity] DESC
-- показать все книги, количество экземпляров которых максимально (и одинаково для всех этих показанных книг).
SELECT [b_name], [b_quantity] FROM [books] WHERE [b_quantity] = (SELECT MAX([b_quantity]) FROM [books])
-- показать книгу (если такая есть), количество экземпляров которой больше, чем у любой другой книги.
SELECT [b_name], b_quantity FROM [books] as ext 
WHERE b_quantity > ALL (SELECT b_quantity FROM books as internal
						WHERE ext.b_id != internal.b_id)
--показать идентификатор одного (любого) читателя, взявшего в библиотеке больше всего книг.
SELECT TOP 1 sb_subscriber, COUNT(sb_subscriber) as total_subscriptions FROM subscriptions GROUP BY sb_subscriber
--показать идентификаторы всех «самых читающих читателей», взявших в библиотеке больше всего книг.
--показать идентификатор «читателя-рекордсмена», взявшего в библиотеке больше книг, чем любой другой читатель.

--показать, сколько в среднем экземпляров книг сейчас на руках у каждого читателя.
SELECT	AVG(CAST([books_per_subscriber] AS FLOAT)) AS [avg_book]
FROM	(SELECT COUNT([sb_book]) AS [books_per_subscriber]
		 FROM [subscriptions]
		 WHERE [sb_is_active] = 'Y'
		 GROUP BY [sb_subscriber]) AS [count_subquery]
--показать, сколько в среднем книг сейчас на руках у каждого читателя.
SELECT AVG(CAST([books_per_subscriber] AS FLOAT)) AS [avg_book]
FROM	(SELECT DISTINCT COUNT([sb_book]) AS [books_per_subscriber]
		 FROM [subscriptions]
		 WHERE [sb_is_active] = 'Y'
		 GROUP BY [sb_subscriber]) AS [count_subquery]
--показать, на сколько в среднем дней читатели берут книги (учесть только случаи, когда книги были возвращены).
SELECT AVG(CAST(DATEDIFF(DAY, sb_start, sb_finish) AS FLOAT)) AS [avg_days] FROM [subscriptions] WHERE [sb_is_active] = 'N'
--показать, сколько в среднем дней читатели читают книгу (учесть оба случая — и когда книга была возвращена, и когда книга не была возвращена)
--показать, сколько в среднем экземпляров книг есть в библиотеке.
SELECT AVG(CAST(b_quantity AS FLOAT)) AS instance_per_book FROM books
--показать в днях, сколько в среднем времени читатели уже зарегистрированы в библиотеке (временем регистрации считать диапазон от первой 
--даты получения читателем книги до текущей даты).
SELECT AVG(CAST(DATEDIFF(DAY, sb_start, GETDATE()) AS FLOAT)) AS avg_time_reg FROM subscriptions

--показать по каждому году, сколько раз в этот год читатели брали книги.
SELECT	YEAR([sb_start]) as [year],
		COUNT([sb_id]) as book_taken
FROM subscriptions
GROUP BY YEAR(sb_start)
ORDER BY [year]
--показать по каждому году, сколько читателей в год воспользовалось услугами библиотеки.
SELECT	YEAR(sb_start) as [year],
		COUNT(DISTINCT sb_subscriber) as subscriptions
FROM subscriptions
GROUP BY YEAR(sb_start)
--показать, сколько книг было возвращено и не возвращено в библиотеку.
SELECT	(CASE 
			WHEN sb_is_active = 'y' 
			then 'Returnetd'
			else 'Not returned'
		 END) as [status],
		COUNT(sb_book) as book
from subscriptions
GROUP BY (CASE 
			WHEN sb_is_active = 'y' 
			then 'Returnetd'
			else 'Not returned'
		 END)
ORDER BY [status]
-- переписать решение 2.1.10.c так, чтобы при подсчёте возвращённых и невозвращённых книг СУБД оперировала исходными значениями 
-- поля sb_is_active (т.е. Y и N), а преобразование в «Returned» и «Not returned» происходило после подсчёта.

--		2.2. Выборка из нескольких таблиц
--показать всю человекочитаемую информацию обо всех книгах (т.е. название, автора, жанр).
SELECT	b_name,
		a_name,
		g_name
FROM	[books]
		JOIN [m2m_books_genres]
		ON [books].b_id = [m2m_books_genres].b_id
		JOIN [genres]
		ON [genres].g_id = [m2m_books_genres].g_id
		JOIN [m2m_books_authors]
		ON [books].b_id = [m2m_books_authors].b_id
		JOIN authors
		ON authors.a_id = [m2m_books_authors].a_id
ORDER BY g_name
--показать всю человекочитаемую информацию обо всех обращениях в библиотеку (т.е. имя читателя, название взятой книги).
SELECT
	b_name,
	s_id,
	s_name,
	sb_start,
	sb_finish
FROM	books
		JOIN [subscriptions]
		ON books.b_id = subscriptions.sb_book
		JOIN subscribers
		ON subscribers.s_id = subscriptions.sb_subscriber
ORDER BY s_id
--показать список книг, у которых более одного автора.
SELECT
		b_name
FROM	books
		JOIN m2m_books_authors
		ON books.b_id = m2m_books_authors.b_id
		JOIN authors
		ON authors.a_id=m2m_books_authors.a_id
GROUP BY b_name
HAVING COUNT(b_name) > 1
--показать список книг, относящихся ровно к одному жанру.
SELECT 
		b_name
FROM	books
		JOIN m2m_books_genres
		ON books.b_id = m2m_books_genres.b_id
		JOIN genres
		ON genres.g_id = m2m_books_genres.g_id
GROUP BY b_name
HAVING COUNT(b_name) = 1

--показать все книги с их авторами (дублирование названий книг не допускается).
SELECT
		b_name as book,
		STRING_AGG([authors].[a_name], ', ') WITHIN GROUP (ORDER BY [a_name] ASC) as [authors(s)]
FROM	books
		JOIN m2m_books_authors
		ON books.b_id = m2m_books_authors.b_id
		JOIN authors
		ON authors.a_id=m2m_books_authors.a_id
GROUP BY b_name;
--показать все книги с их авторами и жанрами (дублирование названий книг и имён авторов не допускается).
WITH [books_names_and_genres] AS
(
	SELECT	
			books.b_id,
			b_name as book,
			STRING_AGG(genres.g_name, ', ') as [genre(s)]
	FROM	[books]
			JOIN [m2m_books_genres]
			ON [books].b_id = [m2m_books_genres].b_id
			JOIN [genres]
			ON [genres].g_id = [m2m_books_genres].g_id
	GROUP BY books.b_id, books.b_name
), [books_names_and_authors] AS
(
	SELECT	
			books.b_id,
			b_name as book,
			STRING_AGG(authors.a_name, ', ') as [author(s)]
	FROM	[books]
			JOIN [m2m_books_authors]
			ON [books].b_id = [m2m_books_authors].b_id
			JOIN authors
			ON authors.a_id = [m2m_books_authors].a_id
	GROUP BY books.b_id, b_name
)
	SELECT 
			[books_names_and_authors].book,
			[books_names_and_authors].[author(s)],
			[books_names_and_genres].[genre(s)]
	FROM	[books_names_and_genres]
			JOIN [books_names_and_authors]
			ON books_names_and_genres.b_id = books_names_and_authors.b_id;
-- показать все книги с их жанрами (дублирование названий книг не допускается).
SELECT
		books.b_name as book,
		STRING_AGG([genres].[g_name], ', ') AS [genre(s)]
FROM 
	books
	JOIN [m2m_books_genres]
	ON books.b_id = m2m_books_genres.g_id
	JOIN genres
	ON genres.g_id = m2m_books_genres.b_id
GROUP BY books.b_name;
-- показать всех авторов со всеми написанными ими книгами и всеми жанрами, в которых они работали (дублирование имён
-- авторов, названий книг и жанров не допускается).
WITH [author_books] AS
(
	SELECT	
			[authors].a_id,
			authors.a_name as author_name,
			STRING_AGG(books.b_name, ', ') as book_name
	FROM	authors
			JOIN m2m_books_authors
			ON authors.a_id = m2m_books_authors.a_id
			JOIN books
			ON books.b_id = m2m_books_authors.b_id
	GROUP BY [authors].a_id, authors.a_name
),	[author_genres] AS
(
	SELECT	
			[authors].a_id,
			STRING_AGG(genres.g_name, ', ') as [genre(s)]
	FROM	authors
			JOIN m2m_books_authors
			ON authors.a_id = m2m_books_authors.a_id
			JOIN books
			ON books.b_id = m2m_books_authors.b_id
			JOIN m2m_books_genres
			ON m2m_books_genres.b_id = books.b_id
			JOIN genres
			ON genres.g_id = m2m_books_genres.g_id
	GROUP BY [authors].a_id
)
	SELECT 
			[author_books].author_name,
			[author_books].book_name,
			author_genres.[genre(s)]
	FROM
		[author_books]
		LEFT JOIN [author_genres]
		ON [author_genres].a_id = [author_books].a_id;
------- Правильный вариант
WITH [author_books] AS
(
	SELECT	
			[authors].a_id,
			authors.a_name as author_name,
			STRING_AGG(books.b_name, ', ') as book_name
	FROM	authors
			JOIN m2m_books_authors
			ON authors.a_id = m2m_books_authors.a_id
			JOIN books
			ON books.b_id = m2m_books_authors.b_id
	GROUP BY [authors].a_id, authors.a_name
),	[authors_genres] AS
(
	SELECT	
			[authors].a_id,
			[authors].a_name,
			[genres].g_name
	FROM	authors
			JOIN m2m_books_authors
			ON authors.a_id = m2m_books_authors.a_id
			JOIN books
			ON books.b_id = m2m_books_authors.b_id
			JOIN m2m_books_genres
			ON m2m_books_genres.b_id = books.b_id
			JOIN genres
			ON genres.g_id = m2m_books_genres.g_id
	GROUP BY [authors].a_id, [authors].a_name, genres.g_name
), [author_genres] AS
(
	SELECT	
			[authors_genres].a_id,
			[authors_genres].a_name,
			STRING_AGG([authors_genres].g_name, ', ') as [genre(s)]
	FROM	[authors_genres]
	GROUP BY [authors_genres].a_id, [authors_genres].a_name
)
	SELECT 
			[author_books].author_name,
			[author_books].book_name,
			author_genres.[genre(s)]
	FROM
		[author_books]
		JOIN [author_genres]
		ON [author_genres].a_id = [author_books].a_id;
	

-- Пример 13: запросы на объединение и подзапросы с условием IN
--показать список читателей, когда-либо бравших в библиотеке книги (использовать JOIN).
SELECT	
		DISTINCT subscribers.s_id,
		subscribers.s_name
FROM subscriptions
	join subscribers
	ON subscribers.s_id = subscriptions.sb_subscriber
--показать список читателей, когда-либо бравших в библиотеке книги (не использовать JOIN).
SELECT	
		s_id,
		s_name
FROM subscribers 
WHERE s_id in (	SELECT sb_subscriber 
				FROM subscriptions)
--показать список читателей, никогда не бравших в библиотеке книги (использовать JOIN).
SELECT	
		subscribers.s_id,
		subscribers.s_name,
		sb_subscriber
FROM subscriptions
	right join subscribers
	ON subscribers.s_id = subscriptions.sb_subscriber
WHERE sb_subscriber is null
--показать список читателей, никогда не бравших в библиотеке книги (не использовать JOIN).
SELECT	
		subscribers.s_id,
		subscribers.s_name
FROM subscribers
WHERE s_id not in (select sb_subscriber from subscriptions)

--показать список книг, которые когда-либо были взяты читателями.
SELECT	b_id,
		b_name
FROM	books
WHERE b_id in (	SELECT sb_book
				FROM subscriptions)
--вариант два
SELECT	distinct b_id,
		b_name
FROM	books
		join subscriptions
		ON books.b_id = sb_book
--показать список книг, которые никто из читателей никогда не брал.
SELECT	b_id,
		b_name
FROM	books
WHERE b_id not in (	SELECT sb_book
					FROM subscriptions)
--вариант два
SELECT	b_id,
		b_name,
		sb_book
FROM	books
		left JOIN subscriptions
		ON b_id = sb_book
WHERE sb_book is null

-- Пример 14: нетривиальные случаи использования условия IN и запросов на объединение

-- показать список читателей, у которых сейчас на руках нет книг (использовать JOIN).
SELECT	s_id,
		s_name
FROM	subscribers
		LEFT JOIN subscriptions
		ON s_id = sb_subscriber
GROUP BY s_id, s_name
HAVING 	COUNT(CASE
				WHEN [sb_is_active] = 'Y' THEN [sb_is_active]
				ELSE NULL
				END) = 0
-- показать список читателей, у которых сейчас на руках нет книг (не использовать JOIN).
SELECT	s_id,
		s_name
FROM	subscribers
WHERE	s_id not in (	SELECT  sb_subscriber
						FROM subscriptions
						WHERE sb_is_active = 'y')
--показать список книг, ни один экземпляр которых сейчас не находится на руках у читателей.
SELECT	b_id,
		b_name
FROM	books
		LEFT outer JOIN subscriptions
		ON b_id = sb_book
GROUP BY b_id, b_name
HAVING	COUNT(	CASE
					WHEN sb_is_active = 'Y' then sb_is_active
					ELSE null
				END) = 0
--второй вариант
SELECT	b_id,
		b_name
FROM	books
WHERE b_id not in (	SELECT sb_book
				FROM subscriptions
				WHERE sb_is_active = 'Y')

---				Пример 15: двойное использование условия IN
--показать книги из жанров «Программирование» и/или «Классика» (без использования JOIN; идентификаторы жанров известны).
SELECT	b_id,
		b_name
FROM	books
WHERE b_id in (	SELECT DISTINCT b_id
				FROM m2m_books_genres
				WHERE g_id in (	2, 5))
--показать книги из жанров «Программирование» и/или «Классика» (без использования JOIN; идентификаторы жанров неизвестны).
SELECT	b_id,
		b_name
FROM	books
WHERE b_id in (	SELECT DISTINCT b_id
				FROM m2m_books_genres
				WHERE g_id in (	SELECT	g_id
								FROM	genres
								WHERE	g_name IN	('Программирование', 'Классика' )
								)
				)
--показать книги из жанров «Программирование» и/или «Классика» (с использованием JOIN; идентификаторы жанров известны).
SELECT	distinct books.b_id,
		b_name
FROM	books
		JOIN m2m_books_genres
		ON books.b_id = m2m_books_genres.b_id
WHERE m2m_books_genres.g_id IN (2,5)
ORDER BY books.b_name
--или 
SELECT	DISTINCT [books].[b_id],
		[b_name]
FROM	[books]
		JOIN [m2m_books_genres]
		ON [books].[b_id] = [m2m_books_genres].[b_id]
WHERE	[g_id] IN ( 2, 5 )
ORDER BY [b_name] ASC

--показать книги из жанров «Программирование» и/или «Классика» (с использованием JOIN; идентификаторы жанров неизвестны).
SELECT	distinct books.b_id,
		b_name
FROM	books
		JOIN m2m_books_genres
		ON books.b_id = m2m_books_genres.b_id
		JOIN genres
		ON m2m_books_genres.g_id = genres.g_id
WHERE genres.g_name IN ('Программирование', 'Классика' )
ORDER BY books.b_name
--или
SELECT	DISTINCT [books].[b_id],
		[b_name]
FROM	[books]
		JOIN [m2m_books_genres]
		ON [books].[b_id] = [m2m_books_genres].[b_id]
WHERE	[g_id] IN (	SELECT [g_id]
					FROM [genres]
					WHERE [g_name] IN ( N'Программирование', N'Классика' )
					)
ORDER BY [b_name] ASC

--показать книги, написанные Пушкиным и/или Азимовым (индивидуально или в соавторстве — не важно).
SELECT	books.b_id,
		books.b_name
FROM	books
		JOIN m2m_books_authors
		ON books.b_id = m2m_books_authors.b_id
		JOIN authors
		ON m2m_books_authors.a_id = authors.a_id
WHERE authors.a_name in ('А.С. Пушкин', 'А. Азимов')
--показать книги, написанные Карнеги и Страуструпом в соавторстве.
SELECT	books.b_id,
		books.b_name
FROM	books
		LEFT JOIN m2m_books_authors
		ON books.b_id = m2m_books_authors.b_id
		LEFT JOIN authors
		ON m2m_books_authors.a_id = authors.a_id
WHERE authors.a_name in ('Д. Карнеги', 'Б. Страуструп')
GROUP BY books.b_id, books.b_name
HAVING   COUNT(books.b_id) = 2

			-- Пример 16: запросы на объединение и функция COUNT
-- показать книги, у которых более одного автора.
SELECT	books.b_id,
		books.b_name,
		COUNT([m2m_books_authors].[a_id]) as count_author
FROM	books
		JOIN m2m_books_authors
		ON books.b_id = m2m_books_authors.b_id
GROUP BY books.b_id, books.b_name
HAVING COUNT(m2m_books_authors.a_id) > 1

-- показать, сколько реально экземпляров каждой книги сейчас есть в библиотеке.
-- Вариант 1: использование коррелирующего подзапроса
SELECT	DISTINCT books.b_id,
		books.b_name,
		(books.b_quantity - (SELECT COUNT(sb_book)
							FROM subscriptions as [int]
							WHERE	sb_is_active = 'Y'
									and int.sb_book = ext.sb_book))
		as real_quantity
FROM	books
		LEFT OUTER JOIN subscriptions as [ext]
		ON books.b_id =  [ext].sb_book
ORDER BY real_quantity DESC;

-- Вариант 2: использование общего табличного выражения и коррелирующего подзапроса
-- Сначала высчитываем колличество взятых книг, а потом в слудющем запросе отнимаем их
WITH [books_taken]
	AS (SELECT	[sb_book]			AS [b_id],
				COUNT([sb_book])	AS [taken]
		FROM [subscriptions]
		WHERE [sb_is_active] = 'Y'
		GROUP BY [sb_book])

SELECT	[b_id],
		[b_name],
		([b_quantity] - ISNULL((SELECT	[taken]
								FROM	[books_taken]
								WHERE [books].[b_id] = [books_taken].[b_id]), 0
								)) 
		AS	[real_count]
FROM [books]
ORDER BY [real_count] DESC 

-- Вариант 3: пошаговое применение общего табличного выражения и подзапроса
-- Сначала высчитываем сколько книг забрали
-- Далее сводим в одну таблицу при этом NULL преобразовываются в 0
-- И в конце вычисляем реальное количество экземпляров книг в библиотеке
WITH [books_taken]
	AS (SELECT [sb_book]
		FROM [subscriptions]
		WHERE [sb_is_active] = 'Y'),
	[real_taken]
	AS (SELECT	[b_id],
				COUNT([sb_book]) AS [taken]
		FROM	[books]
				LEFT OUTER JOIN [books_taken]
				ON [b_id] = [sb_book]
		GROUP BY [b_id])

SELECT	[b_id],
		[b_name],
		([b_quantity] - (	SELECT [taken]
							FROM [real_taken]
							WHERE [books].[b_id] = [real_taken].[b_id]) ) AS
		[real_count]
FROM [books]
ORDER BY [real_count] DESC

-- Вариант 4: без подзапросов
-- Высчитываем сколько книг на руках
-- Вычитываем
WITH [books_taken]
	AS (SELECT [sb_book],
			COUNT([sb_book]) AS [taken]
		FROM [subscriptions]
		WHERE [sb_is_active] = 'Y'
		GROUP BY [sb_book])

SELECT	[b_id],
		[b_name],
		([b_quantity] - ISNULL([taken], 0) ) AS [real_count]
FROM	[books]
		LEFT OUTER JOIN [books_taken]
		ON [b_id] = [sb_book]
ORDER BY [real_count] DESC

--показать авторов, написавших более одной книги.
SELECT	books.b_id,
		authors.a_name,
		COUNT([books].[b_id]) as count_books
FROM	books
		JOIN m2m_books_authors
		ON books.b_id = m2m_books_authors.a_id
		JOIN authors
		ON m2m_books_authors.a_id = authors.a_id
GROUP BY books.b_id, a_name
HAVING COUNT([books].[b_id]) > 1

--показать книги, относящиеся к более чем одному жанру.
SELECT	books.b_id,
		books.b_name,
		COUNT([genres].[g_id]) as count_genres
FROM	books
		join m2m_books_genres
		ON books.b_id = m2m_books_genres.b_id
		JOIN genres
		ON m2m_books_genres.g_id = genres.g_id
GROUP BY books.b_id, books.b_name
HAVING COUNT([genres].[g_id]) > 1

--показать читателей, у которых сейчас на руках больше одной книги.
SELECT	s_id,
		s_name,
		COUNT(s_id) as count_book
FROM	subscribers
		JOIN subscriptions
		ON s_id = sb_subscriber
WHERE sb_is_active = 'Y'
GROUP BY s_id, s_name
HAVING COUNT(s_id) > 1

--показать, сколько экземпляров каждой книги сейчас выдано читателям.
SELECT	sb_book,
		COUNT([subscriptions].[sb_book]) as books_issued
FROM	subscriptions
WHERE sb_is_active = 'Y'
GROUP BY sb_book

--показать всех авторов и количество экземпляров книг по каждому автору.
SELECT	authors.a_name,
		SUM(b_quantity) as total_quantity
FROM	authors
		JOIN m2m_books_authors
		ON authors.a_id = m2m_books_authors.a_id
		JOIN books
		ON m2m_books_authors.b_id = books.b_id
GROUP BY a_name

--показать всех авторов и количество книг (не экземпляров книг, а «книг как изданий») по каждому автору.
SELECT	authors.a_name,
		COUNT(books.b_id) as total_books
FROM	authors
		JOIN m2m_books_authors
		ON authors.a_id = m2m_books_authors.a_id
		JOIN books
		ON m2m_books_authors.b_id = books.b_id
GROUP BY a_name

--показать всех читателей, не вернувших книги, и количество невозвращённых книг по каждому такому читателю.
SELECT	s_id,
		s_name,
		COUNT(s_id) as count_book
FROM	subscribers
		JOIN subscriptions
		ON s_id = sb_subscriber
WHERE sb_is_active = 'Y'
GROUP BY s_id, s_name

	--Пример 17: запросы на объединение, функция COUNT и агрегирующие функции
--показать читаемость авторов, т.е. всех авторов и то количество раз, которое книги этих авторов были взяты читателями.
SELECT	authors.a_id,
		authors.a_name,
		COUNT(subscriptions.sb_book) as books
FROM	authors
		JOIN m2m_books_authors
		ON authors.a_id = m2m_books_authors.a_id
		LEFT OUTER JOIN subscriptions
		ON subscriptions.sb_book = m2m_books_authors.b_id
GROUP BY authors.a_id, authors.a_name
ORDER BY books DESC

--показать самого читаемого автора, т.е. автора (или авторов, если их несколько), книги которого читатели брали чаще всего.
WITH [prepeared_data]
	AS(	SELECT	authors.a_id,
				authors.a_name,
				COUNT(subscriptions.sb_book) as total_books
		FROM	authors
				JOIN m2m_books_authors
				ON authors.a_id = m2m_books_authors.a_id
				LEFT OUTER JOIN subscriptions
				ON subscriptions.sb_book = m2m_books_authors.b_id
		GROUP BY authors.a_id, authors.a_name)
SELECT	a_id,
		a_name,
		total_books
FROM	prepeared_data
WHERE	total_books = (	SELECT	MAX(total_books)
							FROM prepeared_data)
GROUP BY a_id,a_name, total_books;

--показать среднюю читаемость авторов, т.е. среднее значение от того, сколько раз читатели брали книги каждого автора.
WITH [prepeared_data] -- общее табличное выражение
	AS(	SELECT	COUNT(subscriptions.sb_book) as total_books
		FROM	authors
				JOIN m2m_books_authors
				ON authors.a_id = m2m_books_authors.a_id
				LEFT OUTER JOIN subscriptions
				ON subscriptions.sb_book = m2m_books_authors.b_id
		GROUP BY authors.a_id, authors.a_name)
SELECT	AVG(CAST(total_books as FLOAT)) as average_reading
FROM	prepeared_data
-- ВАРИАНТ два
SELECT	AVG(CAST(total_books as FLOAT)) as average_reading
FROM	(SELECT	COUNT(subscriptions.sb_book) as total_books
		FROM	authors
				JOIN m2m_books_authors
				ON authors.a_id = m2m_books_authors.a_id
				LEFT OUTER JOIN subscriptions
				ON subscriptions.sb_book = m2m_books_authors.b_id
		GROUP BY authors.a_id, authors.a_name) as prepeared_data

-- показать медиану читаемости авторов, т.е. медианное значение от того, сколько раз читатели брали книги каждого автора.
WITH [prepeared_data]
	AS(	SELECT	COUNT(subscriptions.sb_book) as total_books
		FROM	authors
				JOIN m2m_books_authors
				ON authors.a_id = m2m_books_authors.a_id
				LEFT OUTER JOIN subscriptions
				ON subscriptions.sb_book = m2m_books_authors.b_id
		GROUP BY authors.a_id, authors.a_name)
SELECT DISTINCT PERCENTILE_DISC(0.5) WITHIN GROUP (ORDER BY total_books) OVER() AS MEDIAN
FROM prepeared_data;

-- написать запрос, проверяющий, не была ли допущена ошибка в заполнении документов, при которой оказывается, что на руках
-- сейчас большее количество экземпляров некоторой книги, чем их было в библиотеке. Вернуть 1, если ошибка есть и 0, если ошибки нет.WITH [books_taken]
	AS (	SELECT	[sb_book],
					COUNT([sb_book]) AS [taken]
			FROM [subscriptions]
			WHERE [sb_is_active] = 'Y'
			GROUP BY [sb_book])

SELECT	TOP 1	CASE
					WHEN EXISTS (	SELECT	TOP 1 [b_id]
									FROM	[books]
											LEFT OUTER JOIN [books_taken]
											ON [b_id] = [sb_book]
									WHERE ([b_quantity] - ISNULL([taken], 0)) < 0)
					THEN 1
					ELSE 0
				END 
		AS [error_exists]
FROM [books_taken]
--показать читаемость жанров, т.е. все жанры и то количество раз, которое книги этих жанров были взяты читателями.
--показать самый читаемый жанр, т.е. жанр (или жанры, если их несколько), относящиеся к которому книги читатели брали чаще всего.
--показать среднюю читаемость жанров, т.е. среднее значение от того, сколько раз читатели брали книги каждого жанра.
--показать медиану читаемости жанров, т.е. медианное значение от того, сколько раз читатели брали книги каждого жанра.
--переписать решение 2.2.7.c{125} для MySQL, MS SQL Server и Oracle с использованием общих табличных выражений.
--реализовать для MS SQL Server альтернативный вариант решения 2.2.7.e{131} для Oracle.

--Пример 18: учёт вариантов и комбинаций признаков
--показать авторов, одновременно работавших в двух и более жанрах (т.е. хотя бы одна книга автора должна одновременно относиться к двум и более жанрам).
SELECT	[a_id],
		[a_name],
		MAX([genres_count]) AS [genres_count]
FROM	(SELECT	authors.a_id,
				authors.a_name,
				COUNT(m2m_books_genres.g_id) as genres_count
		FROM	authors
				JOIN m2m_books_authors
				ON m2m_books_authors.a_id = authors.a_id
				JOIN books
				ON books.b_id = m2m_books_authors.b_id
				JOIN m2m_books_genres
				ON books.b_id = m2m_books_genres.b_id
		GROUP BY authors.a_id,
				authors.a_name,
				[m2m_books_authors].[b_id]
		HAVING COUNT(m2m_books_genres.g_id) > 1	) as prepeared_data
GROUP BY [a_id],[a_name]
-- показать авторов, работавших в двух и более жанрах (даже если каждая отдельная книга автора относится только к одному жанру)

SELECT	prepeared_data.a_id,
		authors.a_name,
		COUNT(prepeared_data.g_id) as genres_count
FROM	(SELECT	distinct [m2m_books_authors].[a_id],
				[m2m_books_genres].[g_id]
		FROM	[m2m_books_genres]
				JOIN [m2m_books_authors]
				ON [m2m_books_genres].[b_id] = [m2m_books_authors].[b_id]) 		AS prepeared_data		JOIN authors		ON authors.a_id = prepeared_data.[a_id]GROUP BY	prepeared_data.a_id, authors.a_nameHAVING COUNT(prepeared_data.g_id) > 1
-- переписать решения задач 2.2.8.a{135} и 2.2.8.b{137} для MS SQL Server и Oracle с использованием общих табличных выражений.
--показать читателей, бравших самые разножанровые книги (т.е. книги, одновременно относящиеся к максимальному количеству жанров).
--показать читателей наибольшего количества жанров (не важно, брали ли они книги, каждая из которых относится одновременно к многим 
--жанрам, или же просто много книг из разных жанров, каждая из которых относится к небольшому количеству жанров).

	--Пример 19: запросы на объединение и поиск минимума, максимума, диапазонов
--показать читателя, первым взявшего в библиотеке книгу.
SELECT	subscribers.s_id,
		s_name
FROM	subscribers
		JOIN subscriptions
		ON subscribers.s_id = subscriptions.sb_subscriber
WHERE subscriptions.sb_start = (SELECT	MIN([subscriptions].[sb_start])
								FROM	subscriptions)
GROUP BY subscribers.s_id, s_name;
-- показать читателя (или читателей, если их окажется несколько), быстрее всего прочитавшего книгу (учитывать только случаи,
--когда книга возвращена).
SELECT	distinct s_id,
		s_name,
		DATEDIFF(DAY, subscriptions.sb_start, subscriptions.sb_finish) as days
FROM	subscribers
		JOIN subscriptions
		ON subscribers.s_id = subscriptions.sb_subscriber
where	subscriptions.sb_is_active = 'N' 
		and DATEDIFF(DAY , sb_start, subscriptions.sb_finish) = (	SELECT	MIN(DATEDIFF(DAY , sb_start, subscriptions.sb_finish))
																	FROM [subscriptions]
																	WHERE subscriptions.sb_is_active = 'N');
--показать, какую книгу (или книги, если их несколько) каждый читатель взял в первый день своей работы с библиотекой.
WITH [first_data_visit]
	AS (
		SELECT	subscriptions.sb_subscriber,
				MIN([subscriptions].[sb_start]) as first_book
		FROM	subscriptions
		GROUP BY sb_subscriber),
	[books_after_first_visit]
	AS (
		SELECT	subscriptions.sb_subscriber,
				subscriptions.sb_book
		FROM	subscriptions
				JOIN first_data_visit
				ON first_data_visit.sb_subscriber = subscriptions.sb_subscriber
					and sb_start = first_data_visit.first_book),
	[subscribers_first_books]
	AS (
		SELECT	subscribers.s_id,
				subscribers.s_name,
				b_name
		FROM	books
				JOIN books_after_first_visit
				ON books.b_id = [books_after_first_visit].sb_book
				JOIN subscribers
				ON subscribers.s_id = [books_after_first_visit].sb_subscriber
		)
SELECT	s_id,
		s_name,
		STRING_AGG(b_name, ' ,') as books
FROM	[subscribers_first_books]
GROUP BY s_id, s_name;

--показать первую книгу, которую каждый из читателей взял в библиотеке.
WITH [first_data_visit]
	AS (
		SELECT	subscriptions.sb_subscriber,
				MIN([subscriptions].[sb_start]) as min_sb_start
		FROM	subscriptions
		GROUP BY sb_subscriber),
	[books_after_first_visit]
	AS (
		SELECT	subscriptions.sb_subscriber,
				MIN([sb_id]) AS [min_sb_id]
		FROM	subscriptions
				JOIN first_data_visit
				ON first_data_visit.sb_subscriber = subscriptions.sb_subscriber
					and sb_start = first_data_visit.min_sb_start
		GROUP BY subscriptions.sb_subscriber),
	[subscribers_first_books]
	AS (
		SELECT	subscriptions.sb_subscriber,
				sb_book
		FROM	subscriptions
				JOIN [books_after_first_visit]
				ON subscriptions.sb_id = books_after_first_visit.min_sb_id
		)
SELECT	[s_id],
		[s_name],
		[b_name]
FROM	[subscribers_first_books]
		JOIN [subscribers]
		ON [sb_subscriber] = [s_id]
		JOIN [books]
		ON [sb_book] = [b_id]
--показать читателя, последним взявшего в библиотеке книгу.
--показать читателя (или читателей, если их окажется  несколько), дольше всего держащего у себя книгу (учитывать только случаи, когда книга не возвращена).
--показать, какую книгу (или книги, если их несколько) каждый читатель взял в свой последний визит в библиотеку.
--показать последнюю книгу, которую каждый из читателей взял в библиотеке.
--переписать решение задачи 2.2.9.c{140} для MySQL с использованием общих табличных выражений.
-- переписать решение задачи 2.2.9.c{140} для MS SQL Server с использованием более компактного синтаксиса группировки
--строковых значений из нескольких рядов выборки (т.е. функции STRING_AGG).
-- переписать первый вариант решения задачи 2.2.9.d{140} для MySQL с использованием общих табличных выражений.
-- написать третий вариант решения задачи 2.2.9.d{140} для MySQL с использованием ранжирования и группировки (по аналогии
--с тем, как это сделано в решениях для MS SQL Server и Oracle).


		--Пример 20: все разновидности запросов на объединение в трёх СУБД

--Задание 2.2.10.TSK.A: показать информацию о том, кто из читателей и когда брал в библиотеке книги.
SELECT	subscribers.s_name,
		subscriptions.sb_start,
		subscriptions.sb_finish
FROM	subscribers
		JOIN subscriptions
		ON subscribers.s_id = subscriptions.sb_subscriber
--Задание 2.2.10.TSK.B: показать информацию обо всех читателях и датах выдачи им в библиотеке книг.
SELECT	subscribers.s_name,
		subscriptions.sb_start,
		subscriptions.sb_finish
FROM	subscribers
		LEFT JOIN subscriptions
		ON subscribers.s_id = subscriptions.sb_subscriber
--Задание 2.2.10.TSK.C: показать информацию о читателях, никогда не бравших в библиотеке книги.
SELECT	subscribers.s_name
FROM	subscribers
		LEFT JOIN subscriptions
		ON subscribers.s_id = subscriptions.sb_subscriber
WHERE sb_start IS NULL
--Задание 2.2.10.TSK.D: показать книги, которые ни разу не были взяты никем из читателей.
SELECT	books.b_name
FROM	books
		LEFT JOIN subscriptions
		ON books.b_id = subscriptions.sb_book
WHERE sb_id IS NULL
--Задание 2.2.10.TSK.E: показать информацию о том, какие книги в принципе может взять в библиотеке каждый из читателей.
SELECT	books.b_name,
		s_id
FROM	books, subscribers
ORDER BY s_id;
--Задание 2.2.10.TSK.F: показать информацию о том, какие книги (при условии, что он их ещё не брал) каждый из читателей может взять в библиотеке.
--Задание 2.2.10.TSK.G: показать информацию о том, какие изданные до 2010-го года книги в принципе может взять в библиотеке каждый из читателей.
--Задание 2.2.10.TSK.H: показать информацию о том, какие изданные до 2010-го года книги (при условии, что он их ещё не брал) может взять в
--библиотеке каждый из читателей.

		--Модификация данных
		--Пример 21: вставка данных
--добавить в базу данных информацию о том, что читатель с идентификатором 4 взял 15-го января 2016-го года в библиотеке
--книгу с идентификатором 3 и обещал вернуть её 30-го января 2016-го года.
INSERT INTO [subscriptions]
			([sb_subscriber],
			[sb_book],
			[sb_start],
			[sb_finish],
			[sb_is_active])
VALUES (4, 3,
 CAST(N'2016-01-15' AS DATE),
 CAST(N'2016-01-30' AS DATE),
 N'N')
--добавить в базу данных информацию о том, что читатель с идентификатором 2 взял 25-го января 2016-го года в библиотеке
--книги с идентификаторами 1, 3, 5 и обещал вернуть их 30-го апреля 2016-го года.
INSERT INTO [subscriptions]
 ([sb_subscriber],
 [sb_book],
 [sb_start],
 [sb_finish],
 [sb_is_active])
VALUES	(2, 1, CAST(N'2016-01-25' AS DATE), CAST(N'2016-04-30' AS DATE), N'N'),
		(2, 3, CAST(N'2016-01-25' AS DATE), CAST(N'2016-04-30' AS DATE), N'N'),
		(2, 5, CAST(N'2016-01-25' AS DATE), CAST(N'2016-04-30' AS DATE), N'N');

	--Пример 22: обновление данных
--у выдачи с идентификатором 99 изменить дату возврата на текущую и отметить, что книга возвращена.
-- Вариант 1: прямая подстановка текущей даты в запрос.
UPDATE	[subscriptions]
SET [sb_finish] = CAST(N'2016-01-06' AS DATE),
	[sb_is_active] = N'N'
WHERE [sb_id] = 99
-- Вариант 2: получение текущей даты на стороне СУБД.
UPDATE	 [subscriptions]
SET	[sb_finish] = CONVERT(date, GETDATE()),
	[sb_is_active] = N'N'
WHERE [sb_id] = 99
--изменить ожидаемую дату возврата для всех книг, которые читатель с идентификатором 2 взял в библиотеке 25-го января
--2016-го года, на «плюс два месяца» (т.е. читатель будет читать их на два месяца дольше, чем планировал).UPDATE [subscriptions]
SET	[sb_finish] = DATEADD(month, 2, [sb_finish])
WHERE [sb_subscriber] = 2 AND [sb_start] = CONVERT(date, '2016-01-25');

--отметить все выдачи с идентификаторами ≤50 как возвращённые.
--для всех выдач, произведённых до 1-го января 2012-го года, уменьшить значение дня выдачи на 3.
--отметить как невозвращённые все выдачи, полученные читателем с идентификатором 2.

	--Пример 23: удаление данных
--удалить информацию о том, что читатель с идентификатором 4 взял 15-го января 2016-го года в библиотеке книгу с идентификатором 3.
DELETE FROM [subscriptions]
WHERE [sb_subscriber] = 4
		AND [sb_start] = CONVERT(date, '2016-01-15')
		AND [sb_book] = 3
--удалить информацию обо всех посещениях библиотеки читателем с идентификатором 3 по воскресеньям.
DELETE FROM [subscriptions]
WHERE [sb_subscriber] = 3
		AND DATEPART(weekday, [sb_start]) = 1

--удалить информацию обо всех выдачах читателям книги с идентификатором 1.
--удалить все книги, относящиеся к жанру «Классика».
--удалить информацию обо всех выдачах книг, произведённых после 20-го числа любого месяца любого года.

	--Пример 24: слияние данных
--добавить в базу данных жанры «Философия», «Детектив», «Классика».
MERGE INTO [genres]
	USING ( VALUES	(N'Философия'),
					(N'Детектив'),
					(N'Классика') ) AS [new_genres]([g_name])
	ON [genres].[g_name] = [new_genres].[g_name]
WHEN NOT MATCHED BY TARGET THEN
 INSERT ([g_name])
 VALUES ([new_genres].[g_name]);
--скопировать (без повторений) в базу данных «Библиотека» содержимое таблицы genres из базы данных «Большая библиотека»; в случае совпадения первичных ключей добавить к существующему имени жанра слово « [OLD]».-- Разрешение вставки явно переданных значений в IDENTITY-поле:
		--Раздел 3: Использование представлений
		--Выборка данных с использованием представлений
		--Пример 26: выборка данных с использованием некэширующих представлений
--упростить использование решения задачи 2.2.9.d{140} так, чтобы для получения нужных данных не приходилось использовать
--представленные в решении{149} объёмные запросы.
--CREATE OR ALTER VIEW [first_book] AS 
--WITH [first_data_visit]
--	AS (
--		SELECT	subscriptions.sb_subscriber,
--				MIN([subscriptions].[sb_start]) as first_book
--		FROM	subscriptions
--		GROUP BY sb_subscriber),
--	[books_after_first_visit]
--	AS (
--		SELECT	subscriptions.sb_subscriber,
--				subscriptions.sb_book
--		FROM	subscriptions
--				JOIN first_data_visit
--				ON first_data_visit.sb_subscriber = subscriptions.sb_subscriber
--					and sb_start = first_data_visit.first_book),
--	[subscribers_first_books]
--	AS (
--		SELECT	subscribers.s_id,
--				subscribers.s_name,
--				b_name
--		FROM	books
--				JOIN books_after_first_visit
--				ON books.b_id = [books_after_first_visit].sb_book
--				JOIN subscribers
--				ON subscribers.s_id = [books_after_first_visit].sb_subscriber
--		)
--SELECT	s_id,
--		s_name,
--		STRING_AGG(b_name, ' ,') as books
--FROM	[subscribers_first_books]
--GROUP BY s_id, s_name; 
--SELECT * FROM "first_book"
--создать представление, позволяющее получать список авторов и количество имеющихся в библиотеке книг по каждому автору,
--но отображающее только таких авторов, по которым имеется более одной книги.
--CREATE OR ALTER VIEW [authors_with_more_than_one_book]
--AS
--SELECT	authors.a_id,
--		authors.a_name,
--		COUNT([authors].[a_id]) as books_in_library
--FROM	authors
--		JOIN m2m_books_authors
--		ON m2m_books_authors.a_id = authors.a_id
--GROUP BY authors.a_id, authors.a_name
--HAVING COUNT(authors.a_id) > 1;

--упростить использование решения задачи 2.2.8.b{135} так, чтобы для получения нужных данных не приходилось использовать
--представленные в решении{137} объёмные запросы.
--создать представление, позволяющее получать список читателей с количеством находящихся у каждого читателя на руках книг, но\
--отображающее только таких читателей, по которым имеются задолженности, т.е. на руках у читателя есть хотя бы одна книга, 
--которую он должен был вернуть до наступления текущей даты.
--переписать решение 3.1.1.a{223} для MySQL версии 8 и новее (с использованием ранжирования и общих табличных выражений




		--Раздел 4: Использование триггеров
	--Агрегация данных с использованием триггеров
--Пример 31: обновление кэширующих таблиц и полей

--модифицировать схему базы данных «Библиотека» таким образом, чтобы таблица subscribers хранила актуальную информацию о дате последнего визита читателя в библиотеку.
--модификация таблицы
--ALTER TABLE [subscribers]
--	ADD [s_last_visit] DATE NULL DEFAULT NULL;
----инициализация данных
--UPDATE [subscribers]
--SET s_last_visit = p.last_visit
--FROM [subscribers]
--	LEFT JOIN (	SELECT	[subscriptions].[sb_subscriber],
--						MAX([subscriptions].[sb_start]) as [last_visit]
--				FROM subscriptions
--				GROUP BY sb_subscriber) as [p]
--	ON s_id = p.sb_subscriber;

--Создание тригера
CREATE TRIGGER [last_visit_on_subscriptions_ins_upd_del]
ON [subscriptions]
AFTER INSERT, UPDATE, DELETE
AS 
	UPDATE [subscribers]
SET s_last_visit = p.last_visit
FROM [subscribers]
	LEFT JOIN (	SELECT	[subscriptions].[sb_subscriber],
						MAX([subscriptions].[sb_start]) as [last_visit]
				FROM subscriptions
				GROUP BY sb_subscriber) as [p]
	ON s_id = p.sb_subscriber;

--создать кэширующую таблицу averages, содержащую в любой момент времени следующую актуальную информацию:
--а) сколько в среднем книг находится на руках у читателя;
--б) за сколько в среднем по времени (в днях) читатель прочитывает книгу;
--в) сколько в среднем книг прочитал читатель
CREATE TABLE [averages]
(
[books_taken] DOUBLE PRECISION NOT NULL,
[days_to_read] DOUBLE PRECISION NOT NULL,
[books_returned] DOUBLE PRECISION NOT NULL
)

SELECT * FROM [averages]