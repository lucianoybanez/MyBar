(function(){
	var app = angular.module('StoreModule',[]);	
	
	app.controller('StoreController', function(){
		this.products = gems;
	});	

	var gems = [{
		name: 'Decoration',
		price: 2.55,
		description: 'mydescription',
		canPurchase: true,
	},{
		name: 'Decoration 2',
		price: 5,
		description: 'mydescription 2',
		canPurchase: false,
	}];
})();
