-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 13, 2023 at 04:21 PM
-- Server version: 5.7.41-log
-- PHP Version: 8.0.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cutcot-info-system`
--
CREATE DATABASE IF NOT EXISTS `cutcot-info-system` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `cutcot-info-system`;

-- --------------------------------------------------------

--
-- Table structure for table `business_clearance`
--

CREATE TABLE `business_clearance` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `business` text NOT NULL,
  `address` text NOT NULL,
  `date` int(11) NOT NULL,
  `month` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `hearings`
--

CREATE TABLE `hearings` (
  `id` int(11) NOT NULL,
  `schedule` date NOT NULL,
  `remarks` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `party_information`
--

CREATE TABLE `party_information` (
  `party_info_id` bigint(20) UNSIGNED NOT NULL,
  `name` text NOT NULL,
  `address` text NOT NULL,
  `age` int(11) NOT NULL,
  `contact` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `reports`
--

CREATE TABLE `reports` (
  `case_no` bigint(20) UNSIGNED NOT NULL,
  `type` text NOT NULL,
  `nature_of_dispute` text NOT NULL,
  `record_photo` text,
  `date` date NOT NULL,
  `first_party_info` bigint(20) NOT NULL,
  `second_party_info` bigint(20) NOT NULL,
  `page` int(11) NOT NULL,
  `first_hearing` int(11) DEFAULT NULL,
  `second_hearing` int(11) DEFAULT NULL,
  `third_hearing` int(11) DEFAULT NULL,
  `status` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `requests`
--

CREATE TABLE `requests` (
  `id` int(11) NOT NULL,
  `document_type` text NOT NULL,
  `requested_by` text NOT NULL,
  `status` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `water_clearance`
--

CREATE TABLE `water_clearance` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `birthdate` date NOT NULL,
  `address` text NOT NULL,
  `date` int(11) NOT NULL,
  `month` int(11) NOT NULL,
  `age` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `wiring_clearance`
--

CREATE TABLE `wiring_clearance` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `age` int(11) NOT NULL,
  `birthdate` date NOT NULL,
  `address` text NOT NULL,
  `month` int(11) NOT NULL,
  `date` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `business_clearance`
--
ALTER TABLE `business_clearance`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `hearings`
--
ALTER TABLE `hearings`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `party_information`
--
ALTER TABLE `party_information`
  ADD PRIMARY KEY (`party_info_id`);

--
-- Indexes for table `reports`
--
ALTER TABLE `reports`
  ADD PRIMARY KEY (`case_no`);

--
-- Indexes for table `requests`
--
ALTER TABLE `requests`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `water_clearance`
--
ALTER TABLE `water_clearance`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `wiring_clearance`
--
ALTER TABLE `wiring_clearance`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `hearings`
--
ALTER TABLE `hearings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `party_information`
--
ALTER TABLE `party_information`
  MODIFY `party_info_id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `reports`
--
ALTER TABLE `reports`
  MODIFY `case_no` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `requests`
--
ALTER TABLE `requests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
