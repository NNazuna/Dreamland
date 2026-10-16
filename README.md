<h1 align="center">Dreamland</h1>

<p align="center">
  Game platformer aksi 2D bertema fantasi, dibuat dengan Unity.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Unity-2022.3.47f1-black?logo=unity" alt="Unity 2022.3.47f1">
  <img src="https://img.shields.io/badge/genre-2D%20platformer-8a5cf6" alt="2D platformer">
</p>

---

## Cerita

Pemain mengendalikan **Princess**, penjaga Dunia Ajaib yang bersenjata tongkat sihir. Dunia Ajaib terancam oleh **The Nightmare Sorcerer**, penyihir jahat yang menciptakan monster untuk menghancurkannya. Princess harus mengalahkan musuh, mengumpulkan pecahan tongkat ajaib, lalu menghadapi sang penyihir di pertarungan bos terakhir.

## Kontrol

| Tombol | Aksi |
| --- | --- |
| **A / D** atau **← / →** | Bergerak |
| **Spasi** | Lompat (bisa lompat dua kali di udara) |
| **S** saat di udara | Turun cepat |
| **Klik kiri** | Tembak sihir |
| **Klik kanan** + arah | Dash (ada jeda pendinginan 1 detik) |

## Fitur

- Gerakan platformer: double jump, dash dengan cooldown, dan fast fall.
- Serangan tembakan sihir dari tongkat.
- Musuh minion es, duri es, dan bola salju sebagai rintangan.
- Pertarungan bos dengan bar nyawa.
- Checkpoint untuk respawn.
- Latar parallax berlapis untuk kesan kedalaman.
- Menu utama, menu jeda, dan pengaturan.

## Menjalankan proyek

1. Install **Unity 2022.3.47f1** lewat Unity Hub (versi 2022.3 LTS lain biasanya juga bisa).
2. Clone repositori ini:
   ```bash
   git clone https://github.com/NNazuna/Dreamland.git
   ```
3. Di Unity Hub pilih **Add › Add project from disk**, lalu pilih folder hasil clone.
4. Buka scene `Assets/Scenes/Mainmenu.unity` dan tekan **Play**.

## Struktur

```
Assets/
├── Scenes/     Mainmenu, stage1
├── Scripts/    Pemain, musuh, bos, peluru, kamera, menu
├── Princess/   Sprite dan animasi karakter utama
├── player/     Animasi pemain (dash, dll.)
└── Map/        Tileset level
```

## Kredit aset

Proyek ini memakai aset gratis berikut. Hak cipta tetap milik pembuat masing-masing.

- Free 2D Pixel Trees Kit
- Free Stylized Skybox
- Pixel Skies DEMO
- Woods Tileset and Background oleh karsiori

---

<p align="center">Dibuat oleh <a href="https://github.com/NNazuna">NNazuna</a></p>
