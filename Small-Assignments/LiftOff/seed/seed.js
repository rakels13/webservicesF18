const MongoClient = require('mongodb').MongoClient;

const arguments = process.argv.slice(2);

if (!arguments.find(a => a === '--connectionString')) {
    console.error('Missing --connectionString');
    return;
}

const connection = arguments[arguments.indexOf('--connectionString') + 1];
if (!connection) {
    console.error('Missing value for connection string!');
    return;
}

MongoClient.connect(connection, {
    useNewUrlParser: true
}, async (err, client) => {
    if (err) { throw new Error(err); }

    const dbName = connection.split('/');
    const db = client.db(dbName[dbName.length - 1]);

    // Populate planets
    const arePlanetsUnpopulated = await db.collection('planets').countDocuments() === 0;
    if (arePlanetsUnpopulated) {
        await db.collection('planets').insertMany([
            { name: 'Mars', diameter: 6779, color: 'red' },
            { name: 'Jupiter', diameter: 139822, color: 'beige' },
            { name: 'Venus', diameter: 12104, color: 'yellowish-white' },
            { name: 'Mercury', diameter: 4879, color: 'gray' },
            { name: 'Neptune', diameter: 49244, color: 'deep-blue' },
            { name: 'Saturn', diameter: 116464, color: 'yellow' },
            { name: 'Uranus', diameter: 50724, color: 'pale-blue' }
        ]);
    }

    // Populate coordinates
    const areCoordinatesUnpopulated = await db.collection('coordinates').countDocuments() === 0;
    if (areCoordinatesUnpopulated) {
        const planets = await db.collection('planets').find({}).toArray();
        planets.map(async p => {
            await db.collection('coordinates').insertMany([
                { latitude: 80, longitude: 101, planetId: p._id },
                { latitude: 10, longitude: 160, planetId: p._id },
                { latitude: -20, longitude: 90, planetId: p._id },
                { latitude: -44, longitude: 66, planetId: p._id },
                { latitude: 63, longitude: -180, planetId: p._id },
            ]);
        });
    }

    client.close();
});
