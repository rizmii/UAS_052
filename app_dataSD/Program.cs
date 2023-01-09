using app_dataSD;

namespace app_dataSD
{

    class Node
    {

        public int NIS;
        public string namaSiswa;
        public int kelasSiswa;
        public Node Next;


    }
    internal class Program
    {

        Node START;
        public void List()
        {
            START = null;
        }

        public void addNode()
        {
            int rollNo, kelas;
            string nama;
            Console.Write("masukkan Nomor Induk siswa: ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("masukkan nama siswa: ");
            nama = Console.ReadLine();
            Console.Write("masukkan kelas siswa (1-6) : ");
            kelas = Convert.ToInt32(Console.ReadLine());
            Node newNode = new Node();
            newNode.NIS = rollNo;
            newNode.namaSiswa = nama;
            newNode.kelasSiswa = kelas;


            if (START == null || rollNo <= START.NIS)
            {
                if ((START != null) && (rollNo == START.NIS))
                {
                    Console.WriteLine("");
                    return;
                }
                newNode.Next = START;
                START = newNode;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (rollNo >= current.NIS))
            {
                if (rollNo == current.NIS)
                {
                    Console.WriteLine("");
                    return;
                }
                previous = current;
                current = current.Next;
            }
            newNode.Next = current;
            previous.Next = newNode;
        }
        public bool DelNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            previous.Next = current.Next;
            if (current == START)
                START = START.Next;
            return true;
        }
        public bool Search(int kelas, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (kelas != current.kelasSiswa))
            {
                previous = current;
                current = current.Next;
            }
            if (current == null)
                return false;
            else
                return true;
        }
       
        public void Traverse()
        {
            if (ListEmpty())
                Console.WriteLine("\nthe records in the list are: ");
            else
            {
                Console.WriteLine("\nthe records in the list are: ");
                Node currentnode;
                for (currentnode = START; currentnode != null;
                    currentnode = currentnode.Next)
                {
                    Console.Write(currentnode.NIS + " "
                        + currentnode.namaSiswa + " " + currentnode.kelasSiswa + "\n");
                }
                Console.WriteLine("");
            }

        }
        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }


        private static void Main(string[] args)
        {
            Program prg = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nmenu");
                    Console.WriteLine("1. Tambahkan data siswa");
                    Console.WriteLine("2. Menghapus data siswa");
                    Console.WriteLine("3. Tampilkan seluruh data siswa");
                    Console.WriteLine("4. Cari data siswa");
                    Console.WriteLine("5. exit");
                    Console.Write("\nenter your choice (1-5): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                prg.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (prg.ListEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.WriteLine("masukkan nomor induk siswa yang ingin dihapus: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (prg.DelNode(rollNo) == false)
                                    Console.WriteLine("\n record not found .");
                                else
                                    Console.WriteLine("data siswa dengan nomor induk " +" "
                                        +rollNo + "telah dihapus");

                            }
                            break;
                        case '3':
                            {
                                prg.Traverse();
                            }
                            break;
                        case '4':
                            {
                                if (prg.ListEmpty() == true)
                                {
                                    Console.WriteLine("\ntidak ada data");
                                    break;

                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nmasukkan kelas yang ingin dicari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (prg.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nrecord not found");
                                else
                                {
                                    Console.WriteLine("\nrecord found");
                                    Console.WriteLine("\nNomor Induk: " + current.NIS);
                                    Console.WriteLine("\nnama siswa: " + current.namaSiswa);
                                    Console.WriteLine("\nkelas siswa: " + current.kelasSiswa);
                                }

                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\ninvalid");
                                break;
                            }
                      

                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("\ncheck for the value entered");
                }
            }
        }

    }
}

//JAWABAN SOAL
//2. algoritma single link list
//3. TOP pada algoritma stack berguna untuk data yang akan keluar masuk, karena algoritma stack menggunakan
//sistem last in first out (LIFO) yaitu data yang masuk terakhir akan keluar pertama
//4. rear, front
//5.
//a.kedalaman 5
//b.inorder