function onExchangeChange() {
    fetch('https://open.er-api.com/v6/latest/USD')
        .then(res => {
            let from = document.getElementById('fromCurrencyType').value
            let to = document.getElementById('toCurrencyType').value
            let value = document.getElementById('amount').value

            if (!value) return;

            res.json().then(result => {
                let rates = result.rates
                let usdValue = value / rates[from]
                let resultValue = usdValue * rates[to]
                document.getElementById('responseLabel').innerHTML = `${value} ${from} = ${resultValue.toFixed(2)} ${to}`

            })

        })
}