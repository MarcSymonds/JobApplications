-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: job_search
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
-- Table structure for table `job_applications`
--

DROP TABLE IF EXISTS `job_applications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `job_applications` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `job_site_id` int(11) DEFAULT NULL,
  `job_site_reference` varchar(30) DEFAULT NULL,
  `employment_agency_id` int(11) DEFAULT NULL,
  `employment_agency_contact_id` int(11) DEFAULT NULL,
  `employment_agency_reference` varchar(30) DEFAULT NULL,
  `company_name` varchar(45) DEFAULT NULL,
  `company_location` varchar(200) DEFAULT NULL,
  `job_title` varchar(45) DEFAULT NULL,
  `application_date` datetime DEFAULT NULL,
  `last_updated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `FK_app_job_site_idx` (`job_site_id`),
  KEY `FK_app_emp_agency_idx` (`employment_agency_id`),
  KEY `FK_app_emp_agency_contact_idx` (`employment_agency_contact_id`),
  CONSTRAINT `FK_app_emp_agency` FOREIGN KEY (`employment_agency_id`) REFERENCES `employment_agencies` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_app_emp_agency_contact` FOREIGN KEY (`employment_agency_contact_id`) REFERENCES `employment_agency_contacts` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_app_job_site` FOREIGN KEY (`job_site_id`) REFERENCES `job_sites` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `job_applications`
--

LOCK TABLES `job_applications` WRITE;
/*!40000 ALTER TABLE `job_applications` DISABLE KEYS */;
INSERT INTO `job_applications` VALUES (1,NULL,NULL,NULL,NULL,NULL,'IC24','Ashford',NULL,NULL,'2017-04-26 14:17:28'),(2,NULL,NULL,NULL,NULL,NULL,'Impreza','Medway City Estate',NULL,NULL,'2017-04-26 14:22:26'),(3,NULL,NULL,NULL,NULL,NULL,'Tabs FM','Medway City Estate',NULL,NULL,'2017-04-26 14:22:26'),(4,NULL,NULL,NULL,NULL,NULL,'Henry Scheine','Rochester',NULL,NULL,'2017-04-26 14:22:26'),(5,NULL,NULL,NULL,NULL,NULL,'Aurora','Walderslade',NULL,'2017-04-20 00:00:00','2017-04-26 14:22:26'),(6,NULL,'30236701',1,1,'VR/01810R',NULL,'Maidstone','Software Developer - Web Applications C#','2017-04-03 00:00:00','2017-04-26 14:22:26'),(7,NULL,'31854412',NULL,NULL,'NC/GA/SITTET','World Class Entertainment Co','Sittingbourne','.NET Developer','2017-04-03 00:00:00','2017-04-26 14:34:37'),(8,NULL,'31833784',4,2,NULL,NULL,'Tunbridge Wells','SQL Developer','2017-04-05 00:00:00','2017-04-26 14:37:48'),(9,NULL,'32063489',NULL,NULL,NULL,'AD Construction','Sidcup','Software Developer','2017-04-12 00:00:00','2017-04-26 14:39:18'),(10,NULL,'31934213',NULL,NULL,'ASH15782CP',NULL,'Maidstone','IT Support Analyst - IT Support Technician','2017-04-20 00:00:00','2017-04-26 14:42:48'),(11,NULL,NULL,NULL,NULL,NULL,NULL,'Gillingham','Software Developer','2017-04-12 00:00:00','2017-04-26 14:48:03'),(12,NULL,NULL,NULL,NULL,NULL,NULL,'Allington','C# Developer ',NULL,'2017-04-26 14:52:26'),(13,NULL,'890480',NULL,NULL,'VR/01965RR','','Rochester','C# Developer','2017-05-03 13:45:00','2017-05-03 13:47:44'),(15,3,'30957425',1,NULL,'VR/01655RR',NULL,'Rochester','C# ASP.NET Developer','2017-05-08 11:45:00','2017-05-08 11:48:09'),(16,3,'32263844',7,3,'DB/Developer','Shearwater Systems','Canterbury','C# Developer','2017-05-08 12:15:00','2017-05-08 12:16:43'),(17,3,'32270023',4,NULL,'',NULL,'Tunbridge Wells','Web Developers','2017-05-08 12:30:00','2017-05-08 12:28:30'),(18,4,'73727830',8,4,'Totaljobs/RH2871',NULL,'Sevenoaks','ASP.Net C# Developer','2017-05-09 14:35:00','2017-05-09 14:37:21');
/*!40000 ALTER TABLE `job_applications` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-05-09 19:10:31
