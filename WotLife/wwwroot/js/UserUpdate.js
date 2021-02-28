//	User guncelleme formu
var input = document.getElementById("textElement3");
var formGecerliligi = new Array(false, false, false);
var gecersizMesajlar = new Array("SAVASLAR", "NICKNAME", "DAMAGE");
var mesaj = "";
var mesajSavaslar = "";
var mesajNickname = "";
var mesajDamage = "";
var mesajWN = "";

function formBilgileri() {
	alert("BENNNNNNNNN");
    mesaj = "";
	mesajSavaslar = "";
	mesajNickname = "";
	mesajDamage = "";
    var bayrak = false;
	var savasBilgisi = document.getElementById("textElement1").value;
	var nicknameBilgisi = document.getElementById("textElement2").value;
    var damageBilgisi = document.getElementById("textElement3").value;

	formGecerliligi[0] = sayisalVeriKontrol(savasBilgisi);

    for (var j = 0; j < 3; j++) {
        if (j == 0) formGecerliligi[j] = sayisalVeriKontrol(savasBilgisi);
		else if (j == 1) formGecerliligi[j] = isimKontrol(nicknameBilgisi);
        else if (j == 2) formGecerliligi[j] = sayisalVeriKontrol(damageBilgisi);
        else	break;
        if (testEt(j, gecersizMesajlar[j]))	bayrak = true;
        else	continue;
	}

    if (bayrak) {
        // basarisiz
        var x = document.getElementsByClassName("bolme22_2");
        x[0].innerHTML = "<div class = \"bolme22_2\" style = \"color: darkred; width: 100%; font-size: 0.8vw; font-weight: bold; float: left; margin: 0 0 0 3%;\">" + mesaj + "</div>";
        x = document.getElementsByClassName("sonuc");
        x[0].innerHTML = "<div class = \"sonuc\" style = \"color: red; text-align: center; text-shadow: 1px 1px white; font-family: verdana; font-size: 0.8vw;\">güncelleme başarısız!</div>";
    }
    else {
        // basarili
        var x = document.getElementsByClassName("sonuc");
		x[0].innerHTML = "<div class = \"sonuc\" style = \"color: green; text-align: center; text-shadow: 1px 1px white; font-family: verdana; font-size: 0.8vw;\">güncelleme başarılı!</div>";
        x = document.getElementsByClassName("bolme22_2");
        x[0].innerHTML = "<div class = \"bolme22_2\" style = \"color: white; font-weight: bold; float: left;\"></div>";
		
		/* KAYIT */
		mesajSavaslar = savasBilgisi;
		mesajNickname = nicknameBilgisi;
        mesajDamage = damageBilgisi;
        mesajWN = (damageBilgisi * 1.2).toFixed(2);

        x = document.getElementsByClassName("kayitListesi");
        x[0].innerHTML = "<div class = \"kayitListesi\" style = \"font-weight: bold; float: left;\">" +
            "Savaslar: " + mesajSavaslar + "<br>" +
            "Nickname: " + mesajNickname + "<br>" +
            "Damage : " + mesajDamage + "<br>" +
            "WN8: " + mesajWN + "</div>";
        
    }
}

function testEt(num, metin) {
    if (!formGecerliligi[num]) {
        mesaj += "Uygun olmayan bölüm: " + metin + "<br><br>";
        return true;
    }
    else	return false;
}

function isimKontrol(isimDegeri) {
    if (isimDegeri != null && isimDegeri != "" && isimKarakterKontrol(isimDegeri))	return true;
    else	return false;
}

function isimKarakterKontrol(adDegeri) {
    var i = 0;
    do {
        if (adDegeri.charCodeAt(i) >= 48 && adDegeri.charCodeAt(i) <= 57 && adDegeri.length >= 3 || adDegeri.charCodeAt(i) >= 65 && adDegeri.charCodeAt(i) <= 90 && adDegeri.length >= 3 || adDegeri.charCodeAt(i) >= 97 && adDegeri.charCodeAt(i) <= 122 && adDegeri.length >= 3 || adDegeri.charCodeAt(i) == 95) {
            i++;
            continue;
        }
        else	return false;
    } while (i < adDegeri.length);
    return true;
}

function sayisalVeriKontrol(x) {
    if (x != null && x != "" && sayisalVeriKarakterKontrol(x))	return true;
    else	return false;
}

function sayisalVeriKarakterKontrol(t) {
    var i = 0;
    do {
        if (t.charCodeAt(i) <= 57 && t.charCodeAt(i) >= 48) {
            i++;
            continue;
        }
        else return false;
    } while (i < t.length);
    return true;
}


function enterTusunaBasildi(event) {
    if (input.value.length >= 1 && event.keyCode === 13)	formBilgileri();
}

input.addEventListener("keypress", enterTusunaBasildi);
