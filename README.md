# IF3210-2022-Unity-02

## Deskripsi aplikasi.
 Sebuah game pada platform Unity. Game tersebut bernama Survival Shooter: Extended yang merupakan game ekstensi Survival Shooter dari Unity Learn.

## Cara kerja
### Attribute Player
### Orbs
Dibuat 3 orbs berbeda, yaitu Power Orb, Health Orb, dan Speed Orb yang masing-masing akan menambahkan nilai pada atribut player sesuai dengan namanya. Setiap kali object orb dibuat, object akan men-destroy dirinya 10 detik sejak dibuat dengan menggunakan fungsi Destroy. Kemudian, dibuat OrbsManager yang akan men-generate Orb secara random setiap 10 detik dengan menggunakan fungsi InvokeRepeating.

### Additional Mobs
### Game Mode
### Weapon Upgrade
### Local Scoreboard
Score pemain disimpan pada suatu file json terpisah untuk masing-masing mode. Setiap kali pemain menyelesaikan game, score akan disimpan ke file json tersebut. Kemudian, setiap kali pemain memasuki menu scoreboard, nilai yang tersimpan di file json tersebut akan di-load.
### Game Over
Setiap nyawa player mencapai 0, GameOverManager akan me-load scene Game Over yang akan menampilkan state game sesuai dengan game modenya. Pada saat ini pula, game akan menyimpan score pemain ke scoreboard.

## Library yang digunakan dan justifikasi penggunaannya.
Kami tidak menggunakan library eksternal.

## Screenshot aplikasi (dimasukkan dalam folder screenshot).


## Pembagian kerja anggota kelompok.
Pembagian kerja terlampir pada link [berikut](https://docs.google.com/document/d/1vSBOwpcp0-wurAHgAQsOfZsRpDUaGRWDQ8l0TopB-2k/edit?usp=sharing)