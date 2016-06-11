var solc = require('solc');
var fs = require('fs');

var filename = process.argv[2];

function compileContract(filename) {
    console.log('compiling contract', filename);
    var input = fs.readFileSync(filename).toString();
    var output = solc.compile(input, 1); // 1 activates the optimiser
    
    console.dir(output);
}

compileContract(filename);