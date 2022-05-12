let service = [];
let connection = null;

let serviceIdToUpdate = -1;

getdata();
setupSignapR();

function setupSignapR() {
     connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:34200/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ServiceCreated", (user, message) => {
        getdata();
    });

    connection.on("ServiceDeleted", (user, message) => {
        getdata();
    });

    connection.on("ServiceUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};


async function getdata() {
    await fetch('http://localhost:34200/service')
        .then(x => x.json())
        .then(y => {
            service = y;
           // console.log(service);
            display();
        });
}



function display() {
    document.getElementById('resultarea').innerHTML = "";
    service.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" + t.name + "</td><td>" + t.maxSpace + "</td><td>" +
            t.employeeNumer + "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button>` +
             "</td></tr>";
        console.log(t.name);
    });
}

function create() {
    let name = document.getElementById('servicename').value;
    let maxspace = document.getElementById('servicemaxspace').value;
    let employeenumber = document.getElementById('serviceemlpoyeenumber').value;

    fetch('http://localhost:34200/service', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: name,
                maxSpace: maxspace,
                employeeNumer: employeenumber
            }), })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });    
}

function remove(id) {
    fetch('http://localhost:34200/service/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById('servicenameupdate').value = service.find(t => t['id'] == id)['name'];
    document.getElementById('servicemaxspaceupdate').value = service.find(t => t['id'] == id)['maxSpace'];
    document.getElementById('serviceemlpoyeenumberupdate').value = service.find(t => t['id'] == id)['employeeNumer'];
    document.getElementById('updateformdiv').style.display = 'flex';
    serviceIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('servicenameupdate').value;
    let maxspace = document.getElementById('servicemaxspaceupdate').value;
    let employeenumber = document.getElementById('serviceemlpoyeenumberupdate').value;

    fetch('http://localhost:34200/service', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                name: name,
                maxSpace: maxspace,
                employeeNumer: employeenumber,
                id: serviceIdToUpdate
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
