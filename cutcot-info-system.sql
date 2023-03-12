-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 11, 2023 at 06:18 PM
-- Server version: 5.7.41-log
-- PHP Version: 8.2.0

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

--
-- Dumping data for table `business_clearance`
--

INSERT INTO `business_clearance` (`id`, `name`, `business`, `address`, `date`, `month`) VALUES
(3, 'Chris John C. Dela Cruz', 'Karaoke For Rent', 'Chocolate Bar', 22, 2),
(8, 'Khen Manio', 'Bos Spa', 'Calumpit Bulacan', 22, 2),
(9, 'Kuya Wil', 'Wowowin', 'Somewhere in manila', 23, 2),
(12, 'Chris JOhn', 'Bos Spa', 'calumpit', 23, 2);

-- --------------------------------------------------------

--
-- Table structure for table `hearings`
--

CREATE TABLE `hearings` (
  `id` int(11) NOT NULL,
  `schedule` date NOT NULL,
  `remarks` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `hearings`
--

INSERT INTO `hearings` (`id`, `schedule`, `remarks`) VALUES
(1, '2023-02-03', 'I wanna be superman'),
(2, '2023-02-22', 'abc'),
(3, '2023-02-08', ''),
(4, '2023-02-28', 'mitochondria is the powerhouse of the cell'),
(6, '2023-02-28', ''),
(7, '2023-02-28', ''),
(8, '2023-02-23', ''),
(9, '2023-02-28', ''),
(10, '2023-02-02', ''),
(11, '2023-02-28', ''),
(12, '2023-02-24', 'The quick brown fox jumps over the lazy dog'),
(13, '2023-02-02', 'Cool ka lang bakit'),
(14, '2023-02-25', '2nd remark'),
(15, '2023-03-09', ''),
(16, '2023-03-10', 'More Descriptive'),
(17, '2023-02-28', ''),
(18, '2023-02-03', ''),
(19, '2023-02-02', '123123'),
(20, '2023-03-01', 'second hearing I guess'),
(21, '2023-02-28', 'abcde'),
(22, '2023-03-09', 'Chris John Dela Cruz'),
(23, '2023-03-02', 'The quick brown fox jumps over the lazy dog'),
(24, '2023-03-01', 'nagsuntukan sa barangay'),
(25, '2023-03-10', 'Nagkiss'),
(26, '2023-03-23', 'Finish na'),
(27, '2023-03-05', 'All the worlds a stage'),
(28, '2023-03-23', 'Unang pagtagpo'),
(29, '2023-09-09', ''),
(30, '2023-03-05', ''),
(31, '2023-03-06', 'And all the man and woman are merely players');

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

--
-- Dumping data for table `party_information`
--

INSERT INTO `party_information` (`party_info_id`, `name`, `address`, `age`, `contact`) VALUES
(1, 'Chris John Dela Cruz', 'San Pablo', 21, '09051255562'),
(2, 'Kuya Wil', 'Manila', 55, '88888'),
(3, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(4, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(5, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(6, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(7, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(8, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(9, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(10, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(11, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(12, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(13, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(14, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(15, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(16, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(17, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(18, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(19, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(20, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(21, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(22, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(23, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(24, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(25, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(26, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(27, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(28, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(29, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(30, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(31, 'Kuya Wil', '001-2023', 21, '8888'),
(32, 'Harry POtter', 'Cutcot Calumpit', 22, '1234'),
(33, 'Julius Abanel', 'Northfields', 21, '8888'),
(34, 'Jerv Coronel', 'Maunlad', 22, '1234'),
(35, 'Reynaldo San Pedro', '001-2023', 21, '8888'),
(36, 'Khen Manio', 'Cutcot Calumpit', 22, '1234'),
(37, 'Julius abanel', '001-2023', 21, '8888'),
(38, 'Jerv Coronel', 'Cutcot Calumpit', 22, '1234'),
(39, 'Chris John Dela Cruz', '001-2023', 21, '8888'),
(40, 'Claude', 'Cutcot Calumpit', 22, '1234'),
(41, 'Tolits', '001-2023', 21, '8888'),
(42, 'Marites', 'Cutcot Calumpit', 22, '1234');

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

--
-- Dumping data for table `reports`
--

INSERT INTO `reports` (`case_no`, `type`, `nature_of_dispute`, `record_photo`, `date`, `first_party_info`, `second_party_info`, `page`, `first_hearing`, `second_hearing`, `third_hearing`, `status`) VALUES
(1, 'AGREEMENT', 'VAC', '98848-987706.png', '2023-02-28', 1, 2, 23, 19, 20, 21, 'CASE SOLVED'),
(2, 'AGREEMENT', 'Verbal Abuse', '39314-321267.png', '2024-02-29', 29, 30, 54, 12, 22, 23, 'PENDING'),
(3, 'CASE NUMBER', 'Misunderstanding', '410141-117364.png', '2023-02-28', 31, 32, 67, 13, 14, 15, 'WITHDRAWN'),
(4, 'CASE NUMBER', 'Slight Phyical Injury', '830016-292636.png', '2023-02-28', 33, 34, 78, 16, 27, 31, 'CASE SOLVED'),
(5, 'FOR THE RECORD', 'VAC', '894827-26619.png', '2023-02-28', 35, 36, 34, 17, 18, 30, 'REFERRED'),
(6, 'CASE NUMBER', 'Slight Phyical Injury', '941652-721892.png', '2023-03-01', 37, 38, 45, 24, 25, 26, 'CASE SOLVED'),
(7, 'CASE NUMBER', 'Verbal Abuse', '79109-639774.png', '2023-03-05', 39, 40, 56, 29, 0, 0, 'PENDING'),
(8, 'AGREEMENT', 'Damage to Property', '532462-967323.png', '2023-03-05', 41, 42, 11, 28, 0, 0, 'PENDING');

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

--
-- Dumping data for table `requests`
--

INSERT INTO `requests` (`id`, `document_type`, `requested_by`, `status`) VALUES
(3, 'BUSINESS_CLEARANCE', 'Chris John C. Dela Cruz', 'FULFILLED'),
(6, 'WATER_CLEARANCE', 'Julius Abanel', 'UNFULFILLED'),
(7, 'WIRING_CLEARANCE', 'Jerv Coronel', 'FULFILLED'),
(8, 'BUSINESS_CLEARANCE', 'Khen Manio', 'UNFULFILLED'),
(9, 'BUSINESS_CLEARANCE', 'Kuya Wil', 'REMOVED'),
(10, 'WATER_CLEARANCE', 'Mang Kanor', 'UNFULFILLED'),
(11, 'WIRING_CLEARANCE', 'Norman', 'REMOVED'),
(13, 'WATER_CLEARANCE', 'Chris John Dela Cruz', 'UNFULFILLED');

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

--
-- Dumping data for table `water_clearance`
--

INSERT INTO `water_clearance` (`id`, `name`, `birthdate`, `address`, `date`, `month`, `age`) VALUES
(6, 'Julius Abanel', '2023-02-01', 'Northfields', 22, 2, 21),
(10, 'Mang Kanor', '2023-02-23', 'Tikauy', 23, 2, 45),
(13, 'Chris John Dela Cruz', '2023-03-01', 'san pablo', 1, 3, 22);

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
-- Dumping data for table `wiring_clearance`
--

INSERT INTO `wiring_clearance` (`id`, `name`, `age`, `birthdate`, `address`, `month`, `date`) VALUES
(7, 'Jerv Coronel', 23, '2000-02-01', 'Menzyland Maunlad Homes', 2, 22),
(11, 'Norman', 34, '2023-02-23', 'Tikay Malolos', 2, 23);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT for table `party_information`
--
ALTER TABLE `party_information`
  MODIFY `party_info_id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

--
-- AUTO_INCREMENT for table `reports`
--
ALTER TABLE `reports`
  MODIFY `case_no` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `requests`
--
ALTER TABLE `requests`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
