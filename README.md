# IF3210-2022-Unity-02

## Deskripsi aplikasi.
 Sebuah game pada platform Unity. Game tersebut bernama Survival Shooter: Extended yang merupakan game ekstensi Survival Shooter dari Unity Learn.

## Cara kerja
### Attribute Player
Atribut player masing-masing disimpan di dalam suatu script. Kemudian dimasukkan ke dalam komponen object player.
### Orbs
Dibuat 3 orbs berbeda, yaitu Power Orb, Health Orb, dan Speed Orb yang masing-masing akan menambahkan nilai pada atribut player sesuai dengan namanya. Setiap kali object orb dibuat, object akan men-destroy dirinya 10 detik sejak dibuat dengan menggunakan fungsi Destroy. Kemudian, dibuat OrbsManager yang akan men-generate Orb secara random setiap 10 detik dengan menggunakan fungsi InvokeRepeating.

### Additional Mobs
### Game Mode
### Weapon Upgrade
Terdapat kelas WeaponUpgrade yang akan mengupgrade attribute weapon setiap melewati waktu tertentu (zen mode) atau setiap kali menyelesaikan wave boss (wave mode).
### Local Scoreboard
Score pemain disimpan pada suatu file json terpisah untuk masing-masing mode. Setiap kali pemain menyelesaikan game, score akan disimpan ke file json tersebut. Kemudian, setiap kali pemain memasuki menu scoreboard, nilai yang tersimpan di file json tersebut akan di-load.
### Game Over
Setiap nyawa player mencapai 0, GameOverManager akan me-load scene Game Over yang akan menampilkan state game sesuai dengan game modenya. Pada saat ini pula, game akan menyimpan score pemain ke scoreboard.

## Library yang digunakan dan justifikasi penggunaannya.
Kami tidak menggunakan library eksternal.

## Screenshot aplikasi (dimasukkan dalam folder screenshot).


## Pembagian kerja anggota kelompok.
1. Gayuh Tri Rahutami (13519192)
   1. Orbs
   2. Local Scoreboard
   3. Main Menu
   4. Game Over
2. Ryo Richardo (13519193)
   1. Additional Mobs
   2. Game Mode
3. Allief Nuriman (13519221)
   1. Attribute Player
   2. Weapon Upgrade