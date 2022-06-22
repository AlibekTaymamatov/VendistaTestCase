async function selectCommand(selectObject) {
    var value = selectObject.value;
    const url = new URL(`../api/command/${value}`, document.baseURI).href;

    const response = await fetch(url, {
        method: "GET",
        headers: {"Accept": "application/json"}
    });

    if (response.ok)
    {
        let html = "";
        let commands = await response.json();
        for (let i = 1; i <= 4; i++) {
            if (commands[`parameter_Name${i}`]) {
                html += "<div style='display: inline-block; margin-right: 20px;'>";
                html += `<label style='clear: both'>${commands[`parameter_Name${i}`]}` + '</label>';
                html += "<br>";
                html += `<input name="parameter${i}" value="${commands[`parameter_Default_Value${i}`]}">` + '</input>';
                html += "<br>";
                html += "</div>";
            }
        }
        $('#selectDiv').html(html);
    } else {
        showError(`Status: ${response.status}, Comment: ${response.statusText}`);
    }
}

async function sendCommand(sendObject) {
    cleanMessage();
    let command = new Object();
    const allParms = document.querySelectorAll('input');
    const commandId = document.getElementById('idcom');
    command["Command_id"] = commandId.value;
    var terminalId = document.getElementById('terminalId').value;
    console.log(terminalId)

    for (let i = 0; i < allParms.length; i++) {
        if (allParms[i].value) {
            command[`Parameter${i + 1}`] = allParms[i].value
        }
    }

    if (terminalId && !isNaN(terminalId)) {
        const url = new URL(`../api/terminal/${terminalId}`, document.baseURI).href;
        const response = await fetch(url, {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: JSON.stringify(command)
        });

        if (response.ok) {
            const data = await response.json();
            if (data) {
                GetTerminalCommand();
            }
        } else {
            showError(`Status: ${response.status}, Comment: ${response.statusText}`);
        }
    } else {
        messageError("Пожалуйста, введите номер терминала");
    }
    console.dir(command);
}

async function GetTerminalCommand() {
    var terminalId = document.getElementById('terminalId').value;
    const url = new URL(`../api/terminal/${terminalId}`, document.baseURI).href;

    var listCommand = $("#idcom > option").map(function () {
        let map = {
            id: $(this).val(), 
            text: $(this).text()
        };
        return map;
    }).get();

    const response = await fetch(url, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok) {
        let html = "";
        const commands = await response.json();
        try {
            if (commands.items != null) {
                commands.items.reverse()
                for (let i = 0; i < commands.items.length; i++) {
                    {
                        var date = new Date(commands.items[i].time_created);
                        var commName = listCommand.find(item => item.id == commands.items[i].command_id);
                        if (commName) {
                            html += "<tr align='center'>";
                            html += '<td>' + (i+1) + '</td>';
                            html += '<td type="date">' + date.toLocaleString() + '</td>';
                            html += '<td>' + commName.text + '</td>';
                            html += '<td>' + commands.items[i].parameter1 + '</td>';
                            html += '<td>' + commands.items[i].parameter2 + '</td>';
                            html += '<td>' + commands.items[i].parameter3 + '</td>';
                            html += '<td>' + commands.items[i].state_name + '</td>';
                            html += "</tr>";
                        }
                    }
                }
                $('#historyCommand').html(html);
            }
        } catch (err) {
            console.log(err)
        }
    } else {
        showError(`Status: ${response.status}, Comment: ${response.statusText}`);
    }
}

function messageError(message) {
    const text = document.getElementById("messageError");
    text.style.display = "inline-block";
    text.insertAdjacentText("beforeend", " " + message + "!");
}

function cleanMessage() {
    const text = document.getElementById("messageError");
    text.style.display = "none";
    text.innerText = "Ошибка: ";
}