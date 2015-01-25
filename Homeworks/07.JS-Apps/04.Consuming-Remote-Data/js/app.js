;
(function () {
	'use strict';
	
	var counter = 1,
		bookForm = $('#add-book-form');

	$(function() {
		service.getAllBooks(drawBooks, notify);

		bookForm.hide();

		$('#add').on('click', function() {
			bookForm.show();
		});

		$('#close').on('click', function() {
			bookForm.hide();
		});

		$('#add-book').on('click', addBook);
		$('#edit-book').on('click', editBook);
	});

	function drawBooks(data){
		var tableHead = $('<thead>')
				.append($('<tr>')
				.append($('<th>').text('#'))
				.append($('<th>').text('Author'))
				.append($('<th>').text('Title'))
				.append($('<th>').text('ISBN'))
				.append($('<th>').text('Edit/Remove'))
			);

		if (data.results.length > 0) {
			$('.books').append(tableHead);
			$('.books').append($('<tbody>'));

			$(data.results).each(function(index, book){
				var editButton = $('<button>').text('Edit').on('click', function() {
					var bookId = $(this).parent().parent().attr('book-id');
					$('#book-title').val($(this).closest('td').prev().prev().prev().text());
					$('#book-author').val($(this).closest('td').prev().prev().text());
					$('#book-isbn').val($(this).closest('td').prev().text());
					bookForm.show();
				});

				var removeButton = $('<button>').text('Remove').on('click', removeBook);

				$('.books tbody')
					.append($('<tr>')
					.attr('book-Id', book.objectId)
					.append($('<td>').text(counter))
					.append($('<td>').text(book.author))
					.append($('<td>').text(book.title))
					.append($('<td>').text(book.isbn))
					.append($('<td>').append(editButton).append(removeButton))
				);

				counter++;
			});
		} else {
			$('.books').append($('<tbody>').append($('<h1>').text('No results.')));
		}
	}

	function addBook() {
		var editButton = $('<button id="edit-book-button">').text('Edit').on('click', function() {
			var bookId = $(this).parent().parent().attr('book-id');
			$(this).data(bookId);
		});

		var removeButton = $('<button>').text('Remove').on('click', removeBook),
			bookAuthor = $('#book-author').val(),
			bookTitle = $('#book-title').val(),
			bookIsbn = $('#book-isbn').val();

		var data = {
			"author": bookAuthor,
			"title": bookTitle,
			"isbn": bookIsbn
		};

		service.postBook(data, function(data){
			$('.books tbody')
				.append($('<tr>')
				.attr('book-Id', data.objectId)
				.append($('<td>').text(counter))
				.append($('<td>').text(bookAuthor))
				.append($('<td>').text(bookTitle))
				.append($('<td>').text(bookIsbn))
				.append($('<td>').append(editButton).append(removeButton))
			);

			counter++;
		}, notify);
	}

	function editBook(){
		var bookAuthor = $('#book-author').val(),
			bookTitle = $('#book-title').val(),
			bookIsbn = $('#book-isbn').val();

		var data = {
			"author": bookAuthor,
			"title": bookTitle,
			"isbn": bookIsbn
		};

		var bookId = $('#edit-book-button').data();

		service.putBook(bookId, data, function(){
			var thisBookQuery = 'tr[book-id="'+ bookId +'"]',
				book = $(thisBookQuery);
			book.find('td:nth-child(2)').text(bookAuthor);
			book.find('td:nth-child(3)').text(bookTitle);
			book.find('td:nth-child(4)').text(bookIsbn);
		}, notify)
	}

	function removeBook(){
		var bookId = $(this).parent().parent().attr('book-Id'),
			_this = this;

		service.deleteBook(bookId, function(){
			$(_this).parent().parent().remove();
		}, notify)
	}

	function notify(text, type) {
		noty({
			text: text || 'Cannot process AJAX request.',
			type: type || 'error',
			layout: 'topCenter',
			timeout: 5000
		});
	}

}());