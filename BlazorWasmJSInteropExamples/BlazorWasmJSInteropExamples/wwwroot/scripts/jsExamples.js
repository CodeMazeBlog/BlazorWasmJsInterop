export function showAlert(obj) {
	const message = 'Name is ' + obj.name + ' Age is ' + obj.age;
	alert(message);
}

export function emailRegistration(message) {
	const result = prompt(message);
	if (result === '' || result === null)
		return 'Please prvode an email'

	const returnMessage = 'Hi ' + result.split('@')[0] + ' your email: ' + result + ' has been accepted.';
	return returnMessage;
}

export function splitEmailDetails(message) {
	const email = prompt(message);
	if (email === '' || email === null)
		return null;

	const firstPart = email.substring(0, email.indexOf("@"));
	const secondPart = email.substring(email.indexOf("@") + 1);

	return {
		'name': firstPart,
		'server': secondPart.split('.')[0],
		'domain': secondPart.split('.')[1]
	}
}