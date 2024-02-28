window.onload = function () {

    const name = document.getElementById('name');
    const cardnumber = document.getElementById('cardnumber');
    const expirationdate = document.getElementById('expirationdate');
    const securitycode = document.getElementById('securitycode');
    const output = document.getElementById('output');
    const ccicon = document.getElementById('ccicon');
    const ccsingle = document.getElementById('ccsingle');
    const generatecard = document.getElementById('generatecard');


    let cctype = null;

    const swapColor = function (basecolor) {
        document.querySelectorAll('.lightcolor')
            .forEach(function (input) {
                input.setAttribute('class', '');
                input.setAttribute('class', 'lightcolor ' + basecolor);
            });
        document.querySelectorAll('.darkcolor')
            .forEach(function (input) {
                input.setAttribute('class', '');
                input.setAttribute('class', 'darkcolor ' + basecolor + 'dark');
            });
    };

    //Generate random card number from list of known test numbers
    const randomCard = function () {
        let testCards = [
            '4000056655665556',
            '5200828282828210',
            '371449635398431',
            '6011000990139424',
            '30569309025904',
            '3566002020360505',
            '6200000000000005',
            '6759649826438453',
        ];
        let randomNumber = Math.floor(Math.random() * testCards.length);
        cardnumber_mask.unmaskedValue = testCards[randomNumber];
    }
    //generatecard.addEventListener('click', function () {
    //    randomCard();
    //});


    // CREDIT CARD IMAGE JS
    document.querySelector('.preload').classList.remove('preload');
    document.querySelector('.creditcard').addEventListener('click', function () {
        if (this.classList.contains('flipped')) {
            this.classList.remove('flipped');
        } else {
            this.classList.add('flipped');
        }
    })

    //On Input Change Events
    name.addEventListener('input', function () {
        if (name.value.length == 0) {
            document.getElementById('svgname').innerHTML = 'John Doe';
            document.getElementById('svgnameback').innerHTML = 'John Doe';
        } else {
            document.getElementById('svgname').innerHTML = this.value;
            document.getElementById('svgnameback').innerHTML = this.value;
        }
    });

    //On Focus Events
    name.addEventListener('focus', function () {
        document.querySelector('.creditcard').classList.remove('flipped');
    });

    cardnumber.addEventListener('focus', function () {
        document.querySelector('.creditcard').classList.remove('flipped');
    });

    expirationdate.addEventListener('focus', function () {
        document.querySelector('.creditcard').classList.remove('flipped');
    });

    securitycode.addEventListener('focus', function () {
        document.querySelector('.creditcard').classList.add('flipped');
    });
};