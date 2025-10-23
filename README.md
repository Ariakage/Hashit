# Hashit
![star](https://img.shields.io/github/stars/Ariakage/Hashit "star") ![fork](https://img.shields.io/github/forks/Ariakage/Hashit "fork") ![GitHub Last Commit](https://img.shields.io/github/last-commit/Ariakage/Hashit.svg?label=commits "GitHub Last Commit") ![issues](https://img.shields.io/github/issues/Ariakage/Hashit "issues") [![Author](https://img.shields.io/badge/Author-Ariakage-red.svg "Author")](https://ariakage.github.io "Author") [![LICENSE](https://img.shields.io/github/license/Ariakage/Hashit "LICENSE")](./LICENSE "LICENSE")  

> [!NOTE]
> This README has a [Chinese version](README_CN.md)

### Description
Hashit is a .NET-based file hashing tool that supports multiple algorithms, generates JSON-formatted checksum files, and verifies file integrity.

### Features
- Compute file hashes (MD5, SHA1, SHA256, SHA512, CRC32)  
- Save hash results as `<filename>.checksum` in JSON format  
- Verify file hashes against checksum files  
- Simple and clear command-line interface  

### Usage

#### Generate File Hash
To calculate hashes for a file:
```bash
Hashit <file>
```
or
```bash
Hashit -g <file>
```

#### Verify File Hash
To verify a file against its checksum (default uses `<file>.checksum`):
```bash
Hashit -v <file>
```
To specify a custom checksum file:
```bash
Hashit -v <file> -i <checksum-file>
```

#### Help
To display usage instructions:
```bash
Hashit -h
Hashit -help
Hashit --help
```

Example output from help:
```
Usage: Hashit [options] <file>
e.g. (Calculate file hash) Hashit <file> | Hashit -g <file>
     (Verify file hash)   Hashit -v <file> (default reads <filename>.checksum) | Hashit -v <file> -i <checksum-file>
```

### Supported Algorithms
- [x] MD5  
- [x] SHA1  
- [x] SHA256  
- [x] SHA512  
- [x] CRC32  

### Support Me
Please star the project to support it ⭐  
![Stargazers over time](https://starchart.cc/ariakage/Hashit.svg)  

### Project Link
[GitHub - Hashit](https://github.com/Ariakage/Hashit)
