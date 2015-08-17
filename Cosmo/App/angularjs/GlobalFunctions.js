////////////GLOBAL FUNCTIONS/////////////////////

function flashInformation(opts) {
	opts.timeout = opts.timeout ? opts.timeout : 1000;
	opts.canShow = true;
	opts.messageVar = opts.message;
	setTimeout(opts.timeout,function(){
		canShow = false;
	});
}