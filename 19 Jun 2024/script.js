const quotesPerPage = 5;
let currentPage = 1;
let quotes = [];

function foranimation() {
    setTimeout(function() {
        document.querySelectorAll('.top-down').forEach((element) => {
            element.classList.add('visible');
        });
    }, 300);
}

async function fetchQuotes() {
    try {
        const response = await fetch('https://dummyjson.com/quotes');
        const data = await response.json();
        quotes = data.quotes;
        renderQuotes(quotes);
    } catch (error) {
        console.error('Error fetching quotes:', error);
    }
}

document.addEventListener('DOMContentLoaded', () => {
    document.querySelector('nav ul li a[href="#home"]').addEventListener('click', showHome);
    document.querySelector('nav ul li a[href="#quotes"]').addEventListener('click', showQuotes);
    document.getElementById('prev-btn').addEventListener('click', () => changePage(-1));
    document.getElementById('next-btn').addEventListener('click', () => changePage(1));
    document.querySelector('.hamburger-menu').addEventListener('click' ,()  => {
        if(document.querySelector('.hamburger-menu').classList.contains('active')){
            document.querySelector('.hamburger-menu').classList.remove('active');
            document.querySelector('.nav-items').classList.remove('active');
        }
        else{
            document.querySelector('.hamburger-menu').classList.add('active');
        document.querySelector('.nav-items').classList.add('active');
        }
    })
    document.getElementById('searchauthor').addEventListener('input', () => {
        currentPage = 1;
        filterQuotes(document.getElementById('searchauthor').value.trim().toLowerCase());
    });
    document.getElementById('sort').addEventListener('change', () => {
        currentPage = 1;
        sortAndRenderQuotes(document.getElementById('sort').value);
    });
    foranimation();
    fetchQuotes();
});

function showHome() {
    foranimation();
    document.getElementById('home').style.display = 'block';
    document.getElementById('quotes').style.display = 'none';
}

function showQuotes() {
    document.getElementById('home').style.display = 'none';
    document.getElementById('quotes').style.display = 'block';
    renderQuotes(quotes);
}

function filterQuotes(author) {
    const filteredQuotes = quotes.filter((quote) => {
        return quote.author.toLowerCase().includes(author);
    });
    sortAndRenderQuotes(document.getElementById('sort').value, filteredQuotes);
}

function sortQuotes(quotes, order) {
    if (!Array.isArray(quotes) || quotes.length === 0) {
        console.error('Invalid input array for sorting.');
        return [];
    }

    if (order !== 'asc' && order !== 'desc') {
        console.error('Invalid sorting order. Must be "asc" or "desc".');
        return quotes; // Return original quotes if order is invalid
    }

    const comparator = (a, b) => {
        const authorA = a.author.toLowerCase();
        const authorB = b.author.toLowerCase();

        if (order === 'asc') {
            return authorA.localeCompare(authorB);
        } else {
            return authorB.localeCompare(authorA);
        }
    };

    quotes.sort(comparator);

    return quotes;
}

function sortAndRenderQuotes(order, initialQuotes = quotes) {
    const sortedQuotes = sortQuotes(initialQuotes, order);
    renderQuotes(sortedQuotes);
}

function renderQuotes(quotes) {
    const quotesContainer = document.getElementById('quotes-container');
    quotesContainer.innerHTML = '';

    const start = (currentPage - 1) * quotesPerPage;
    const end = start + quotesPerPage;
    const paginatedQuotes = quotes.slice(start, end);

    let incpage = 1; // Start with 1 for delay calculation

    paginatedQuotes.forEach((quote, index) => {
        const quoteCard = document.createElement('div');
        quoteCard.className = 'quote-card top-down';
        quoteCard.innerHTML = `<p class="main-quote">' ${quote.quote} '</p><p>- ${quote.author}</p>`;

        if (index === 0) {
            quoteCard.classList.add('delay-2');
        } else if (index === 1) {
            quoteCard.classList.add('delay-4');
        } else if (index === 2) {
            quoteCard.classList.add('delay-6');
        } else if (index === 3) {
            quoteCard.classList.add('delay-8');
        } else {
            quoteCard.classList.add('delay-8');
        }

        quotesContainer.appendChild(quoteCard);

        void quoteCard.offsetWidth; // Force reflow to trigger CSS animation
        quoteCard.classList.add('visible');
    });

    document.getElementById('page-info').innerText = `Page ${currentPage} of ${Math.ceil(quotes.length / quotesPerPage)}`;
    document.getElementById('prev-btn').disabled = currentPage === 1;
    document.getElementById('next-btn').disabled = currentPage === Math.ceil(quotes.length / quotesPerPage);
}

function changePage(offset) {
    currentPage += offset;
    const searchAuthorValue = document.getElementById('searchauthor').value.trim().toLowerCase();
    filterQuotes(searchAuthorValue);
}
