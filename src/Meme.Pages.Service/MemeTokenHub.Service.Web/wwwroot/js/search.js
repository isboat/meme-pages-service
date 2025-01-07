$(document).ready(function(){
	"use strict";

    const apiKeyQs = "x_cg_demo_api_key=CG-gphvLEo5jN2VdVLydwYL9sgg";
    

    var displayCats = function (items, displayTotal, box) {

        if (displayTotal > 10) displayTotal = 10
        if (items) {
            for (var i = 0; i < displayTotal; i++) {
                var coin = items[i];

                var li = $('<li class="list-group-item"></li>')
                var row = $('<div class = "row"></div>')
                var name = '<div class = "col-md-6">' + coin.name + '</div>'
                var price = '<div class = "col-md-6"><img style="min-width:20px;" src="' + coin.data.sparkline +'" /></div>'

                row.append(name);
                row.append(price);
                li.append(row);
                box.append(li)
            }
        }
    }
    var getTrendingCoins = function () {

        $.ajax({
            url: 'https://api.coingecko.com/api/v3/search/trending?' + apiKeyQs,
            type: 'GET',
            accepts: 'application/json',
            cache: false,
            success: function (response) {
                console.log(response)

                if (response.coins) {
                    //displayList(response.coins, response.coins.length, $(".trending-coins"));
                }
                if (response.nfts) {
                    displayNfts(response.nfts, response.nfts.length, $(".trending-nfts"));
                }
                if (response.categories) {
                    displayCats(response.categories, response.categories.length, $(".trending-cats"));
                }
            }
        });
    }

    getTrendingCoins();
    getExchanges();
    
});