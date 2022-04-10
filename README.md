# IF3210-2022-Unity-02

## Deskripsi aplikasi.
 Sebuah game pada platform Unity. Game tersebut bernama Survival Shooter: Extended yang merupakan game ekstensi Survival Shooter dari Unity Learn.

## Cara kerja
### Attribute Player
Atribut player masing-masing disimpan di dalam suatu script. Kemudian dimasukkan ke dalam komponen object player.
### Orbs
Dibuat 3 orbs berbeda, yaitu Power Orb, Health Orb, dan Speed Orb yang masing-masing akan menambahkan nilai pada atribut player sesuai dengan namanya. Setiap kali object orb dibuat, object akan men-destroy dirinya 10 detik sejak dibuat dengan menggunakan fungsi Destroy. Kemudian, dibuat OrbsManager yang akan men-generate Orb secara random setiap 10 detik dengan menggunakan fungsi InvokeRepeating.

### Additional Mobs
Terdapa beberapa additional mobs yang ditambahkan ke dalam game Survival Shooter:
- Skeleton, mobs yang dapat menyerang player dari jarak jauh
- Bomber, mobs yang memiliki kecepatan dan damage tinggi namun akan meledakkan diri ketika bertemu player
- Boss, mobs yang memiliki HP lebih besar dibandingkan mobs yang lain

### Game Mode
Tersedia 2 jenis game mode dalam game Survival Shooter:
- Wave mode, musuh akan muncul di setiap wave. Setiap wave memiliki jeda 3 detik sebelum wave berikutnya dimulai. Semakin bertambah wave, maka akan semakin tinggi juga tingkat kesulitannya, yang diimplementasikan dari bertambahnya wave weight, bertambahnya HP mobs, dan munculnya mobs skeleton & bomber mulai wave 7. Setiap kelipatan 3 wave akan muncul boss mobs. Tujuan dari Wave mode adalah mengumpulkan score sebanyak mungkin. Wave mode berhenti ketika berhasil menyelesaikan 15 wave.
- Zen mode, semua mobs akan muncul secara terus menerus dalam jeda waktu konstan. Tujuan dari Zen mode adalah bertahan hidup dengan waktu selama mungkin. Zen mode berhenti ketika HP player habis. 
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