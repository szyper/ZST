-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Wrz 23, 2025 at 02:57 PM
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
-- Database: `4ti_kart`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `klienci`
--

CREATE TABLE `klienci` (
  `id_klienta` int(11) NOT NULL,
  `Nazwisko` varchar(50) NOT NULL,
  `Imię` varchar(50) NOT NULL,
  `NIP` char(10) NOT NULL,
  `Kod pocztowy` char(6) NOT NULL,
  `Miasto` varchar(50) NOT NULL,
  `ulica nr domu` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `klienci`
--

INSERT INTO `klienci` (`id_klienta`, `Nazwisko`, `Imię`, `NIP`, `Kod pocztowy`, `Miasto`, `ulica nr domu`) VALUES
(1, 'NoweNazwisko', 'NoweImie', '1234567891', '12-345', 'NoweMiasto', 'Nowe Ulica 1/2');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `sprzedaz`
--

CREATE TABLE `sprzedaz` (
  `id_sprzedaży` int(11) NOT NULL,
  `id_klienta` int(11) NOT NULL,
  `id_towaru` int(11) NOT NULL,
  `ilość` int(11) NOT NULL,
  `data` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `sprzedaz`
--

INSERT INTO `sprzedaz` (`id_sprzedaży`, `id_klienta`, `id_towaru`, `ilość`, `data`) VALUES
(1, 1, 1, 1, '2025-09-09');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `towary`
--

CREATE TABLE `towary` (
  `id_towaru` int(11) NOT NULL,
  `Nazwa towaru` varchar(100) NOT NULL,
  `Cena` decimal(10,2) NOT NULL,
  `Waga` decimal(10,2) NOT NULL,
  `Kolor` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_polish_ci;

--
-- Dumping data for table `towary`
--

INSERT INTO `towary` (`id_towaru`, `Nazwa towaru`, `Cena`, `Waga`, `Kolor`) VALUES
(1, 'Nowytowar', 12345.00, 123.00, 'NowyKolor');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `klienci`
--
ALTER TABLE `klienci`
  ADD PRIMARY KEY (`id_klienta`);

--
-- Indeksy dla tabeli `sprzedaz`
--
ALTER TABLE `sprzedaz`
  ADD PRIMARY KEY (`id_sprzedaży`),
  ADD KEY `id_klienta` (`id_klienta`,`id_towaru`),
  ADD KEY `id_towaru` (`id_towaru`);

--
-- Indeksy dla tabeli `towary`
--
ALTER TABLE `towary`
  ADD PRIMARY KEY (`id_towaru`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `klienci`
--
ALTER TABLE `klienci`
  MODIFY `id_klienta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `sprzedaz`
--
ALTER TABLE `sprzedaz`
  MODIFY `id_sprzedaży` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `towary`
--
ALTER TABLE `towary`
  MODIFY `id_towaru` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `sprzedaz`
--
ALTER TABLE `sprzedaz`
  ADD CONSTRAINT `sprzedaz_ibfk_1` FOREIGN KEY (`id_klienta`) REFERENCES `klienci` (`id_klienta`),
  ADD CONSTRAINT `sprzedaz_ibfk_2` FOREIGN KEY (`id_towaru`) REFERENCES `towary` (`id_towaru`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
