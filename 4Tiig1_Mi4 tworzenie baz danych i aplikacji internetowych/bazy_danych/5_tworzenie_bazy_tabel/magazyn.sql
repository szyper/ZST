-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Paź 06, 2025 at 12:35 PM
-- Wersja serwera: 10.4.32-MariaDB
-- Wersja PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `magazyn`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `dostawcy`
--

CREATE TABLE `dostawcy` (
  `id_dostawcy` int(11) NOT NULL,
  `nazwa` varchar(100) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `telefon` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `dostawcy_produkty`
--

CREATE TABLE `dostawcy_produkty` (
  `id` int(11) NOT NULL,
  `id_dostawcy` int(11) DEFAULT NULL,
  `id_produktu` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `kategorie`
--

CREATE TABLE `kategorie` (
  `id_kategorii` int(11) NOT NULL,
  `nazwa` varchar(50) NOT NULL,
  `opis` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `klienci`
--

CREATE TABLE `klienci` (
  `id_klienta` int(11) NOT NULL,
  `nazwa` varchar(100) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `telefon` varchar(20) DEFAULT NULL,
  `adres` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `magazyny`
--

CREATE TABLE `magazyny` (
  `id_magazynu` int(11) NOT NULL,
  `nazwa` varchar(100) NOT NULL,
  `miasto` varchar(100) DEFAULT NULL,
  `pojemnosc` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `produkty`
--

CREATE TABLE `produkty` (
  `id_produktu` int(11) NOT NULL,
  `id_kategorii` int(11) NOT NULL,
  `nazwa` varchar(100) NOT NULL,
  `cena` decimal(10,2) DEFAULT NULL,
  `jednostka` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `stany_magazynowe`
--

CREATE TABLE `stany_magazynowe` (
  `id_stanu` int(11) NOT NULL,
  `id_produktu` int(11) DEFAULT NULL,
  `id_magazynu` int(11) DEFAULT NULL,
  `ilosc` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `dostawcy`
--
ALTER TABLE `dostawcy`
  ADD PRIMARY KEY (`id_dostawcy`);

--
-- Indeksy dla tabeli `dostawcy_produkty`
--
ALTER TABLE `dostawcy_produkty`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_dostawcy` (`id_dostawcy`,`id_produktu`),
  ADD KEY `id_produktu` (`id_produktu`);

--
-- Indeksy dla tabeli `kategorie`
--
ALTER TABLE `kategorie`
  ADD PRIMARY KEY (`id_kategorii`),
  ADD UNIQUE KEY `nazwa` (`nazwa`);

--
-- Indeksy dla tabeli `klienci`
--
ALTER TABLE `klienci`
  ADD PRIMARY KEY (`id_klienta`);

--
-- Indeksy dla tabeli `magazyny`
--
ALTER TABLE `magazyny`
  ADD PRIMARY KEY (`id_magazynu`);

--
-- Indeksy dla tabeli `produkty`
--
ALTER TABLE `produkty`
  ADD PRIMARY KEY (`id_produktu`),
  ADD KEY `id_kategorii` (`id_kategorii`);

--
-- Indeksy dla tabeli `stany_magazynowe`
--
ALTER TABLE `stany_magazynowe`
  ADD PRIMARY KEY (`id_stanu`),
  ADD KEY `id_produktu` (`id_produktu`,`id_magazynu`),
  ADD KEY `id_magazynu` (`id_magazynu`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `dostawcy`
--
ALTER TABLE `dostawcy`
  MODIFY `id_dostawcy` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `dostawcy_produkty`
--
ALTER TABLE `dostawcy_produkty`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `kategorie`
--
ALTER TABLE `kategorie`
  MODIFY `id_kategorii` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `klienci`
--
ALTER TABLE `klienci`
  MODIFY `id_klienta` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `magazyny`
--
ALTER TABLE `magazyny`
  MODIFY `id_magazynu` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `produkty`
--
ALTER TABLE `produkty`
  MODIFY `id_produktu` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `stany_magazynowe`
--
ALTER TABLE `stany_magazynowe`
  MODIFY `id_stanu` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `dostawcy_produkty`
--
ALTER TABLE `dostawcy_produkty`
  ADD CONSTRAINT `dostawcy_produkty_ibfk_1` FOREIGN KEY (`id_produktu`) REFERENCES `produkty` (`id_produktu`),
  ADD CONSTRAINT `dostawcy_produkty_ibfk_2` FOREIGN KEY (`id_dostawcy`) REFERENCES `dostawcy` (`id_dostawcy`);

--
-- Constraints for table `produkty`
--
ALTER TABLE `produkty`
  ADD CONSTRAINT `produkty_ibfk_1` FOREIGN KEY (`id_kategorii`) REFERENCES `kategorie` (`id_kategorii`);

--
-- Constraints for table `stany_magazynowe`
--
ALTER TABLE `stany_magazynowe`
  ADD CONSTRAINT `stany_magazynowe_ibfk_1` FOREIGN KEY (`id_produktu`) REFERENCES `produkty` (`id_produktu`),
  ADD CONSTRAINT `stany_magazynowe_ibfk_2` FOREIGN KEY (`id_magazynu`) REFERENCES `magazyny` (`id_magazynu`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
