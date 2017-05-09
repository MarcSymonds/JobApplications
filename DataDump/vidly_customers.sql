-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: vidly
-- ------------------------------------------------------
-- Server version	5.7.16-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `IsSubscribedToNewsLetter` tinyint(1) NOT NULL,
  `MembershipTypeId` tinyint(3) unsigned NOT NULL,
  `dateOfBirth` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_MembershipTypeId` (`MembershipTypeId`) USING HASH,
  CONSTRAINT `FK_Customers_MembershipTypes_MembershipTypeId` FOREIGN KEY (`MembershipTypeId`) REFERENCES `membershiptypes` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (8,'Geordie La Forge',1,2,'1997-01-01 00:00:00'),(9,'Doctor Beverley Crusher',0,3,'1998-01-01 00:00:00'),(11,'Worf',0,1,'1996-01-01 00:00:00'),(12,'Tasha Yar',1,3,'1995-01-01 00:00:00'),(13,'Will Riker',1,4,'1994-01-01 00:00:00'),(15,'Data',0,1,'1992-01-01 00:00:00'),(16,'Jean Lucd Picard',1,2,'1991-01-01 00:00:00'),(17,'Deanna Troy',0,3,'1990-01-01 00:00:00'),(19,'test2',0,2,'1980-01-01 00:00:00'),(21,'test4',0,4,'1980-01-01 00:00:00'),(22,'test5',0,1,'1980-01-01 00:00:00'),(23,'test6',0,2,'1980-01-01 00:00:00'),(24,'test7',0,3,'1980-01-01 00:00:00'),(25,'test8',0,4,'1980-01-01 00:00:00'),(26,'test9',0,1,'1980-01-01 00:00:00'),(27,'test10',0,2,'1980-01-01 00:00:00');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-05-09 19:10:33
