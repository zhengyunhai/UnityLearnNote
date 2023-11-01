# C#ʰ��
## ��������
### �ֶΡ�����
1. �ֶ�����ĸСд��һ����private����
    - һ���������ڲ������L��
    - �������������ʹ��
2. ��������ĸ��д������public����
    - ͨ���ǹ��ⲿ���L�ʵ�
    - ���Ա�����ʵ����һ��������ͨ��get��set������������Ӧ���ֶ�
    - ���Կ����ж�Ӧ���ֶΣ�Ҳ����û�У�**C#�����Զ��ں�̨Ϊ���Դ����ֶ�**��
    - ���ã�
      - **������ַǷ����ݡ�����������Ե�set���������߼��ж�**
3. ע��
   - **ʹ������ʱ�����޶�Ӧ�ֶΣ�����������Ϊ������ʽ**

```C#
    public int SumBulletCount { get; set; }
```
  -  ���ж�Ӧ�ֶΣ���������������ʽ��������,����get��set���������ٱ���һ����

```C#
        private int curBulletCount;
        public int CurBulletCount { 
            get { return curBulletCount; } 
            set { curBulletCount = value; }
        }
```
   - **�����������ʽ**��
```C#
    private int curBulletCount;
    public int CurBulletCount { get; set; }
```
�Ը�**����**��ʽ���������ڳ�����ʹ���ֶΣ�curBulletCountֵ**ʼ��Ϊ0**��
    - ��һ�ִ����������ʽ��
```C#
private int curBulletCount;
        public int CurBulletCount { 
            get { return CurBulletCount; } //�᲻�ϵ���get�����������Զ����ֶΣ���ѭ��
            set { curBulletCount = value; }
        }
```

4. ����
   - �ֶ�����Ϊref,out���������Բ���
---


### ��������

#### �ֵ�Dictionary

�洢��ֵ�ԡ�**��ȡ�����ٶȿ������顣**

#### ����

- ���ȿɱ䣬�洢�ռ䲻һ�����������������飩
- ���ͣ�
  - �Ƿ��ͼ��ϣ�
    - **���Դ洢�������͵�����**
    - ���ܲ��ã����ܷ���װ����䣻���Ͳ���ȫ��ʹ�ò����㣬���ж�����ʱ��Ҫ�ֶ�����ת��
    - �����ռ� System.Collections
  - ���ͼ��ϣ�
    - **���͹̶�**
    - �����ռ� System.Collections.Generic

```C#
//�б�
        ArrayList arrayList= new ArrayList();
        arrayList.Add(1);
        arrayList.Add(gameObject);//���Է��벻ͬ���͵�����

        List<string> list= new List<string>();//��������Ϊstring
        //list.Add(gameObject);//���Ͳ�һ�£�����
        list.Add(gameObject.name);

//�ֵ�
        //�Ƿ����ֵ�
        Hashtable table1= new Hashtable();
        table1.Add("����", "damage");
        table1.Add("xiangmu",213);
        table1.Add("cube", gameObject);
        foreach(var item in table1.Keys ) Debug.Log(item + "**" + table1[item]);
        //�����ֵ�
        Dictionary<string,string> table2= new Dictionary<string,string>();
        table2.Add("xiangmu", "123");
        Debug.Log(table2["xiangmu"]);
        string res;
        table2.TryGetValue("meiyou", out res);
        //�ֵ�Ƕ��
        Dictionary<string,Dictionary<string,string>> table3=new Dictionary<string, Dictionary<string, string>>();
        table3.Add("Tom",new Dictionary<string,string>());
        table3["Tom"].Add("address", "beijing");
        table3["Tom"].Add("phone", "15432323");
        Debug.Log(table3["Tom"]["address"]);

//ջ
        stack01= new Stack<string>();
        stack01.Push("mainMenu");
        stack01.Push("itemMenu");
        stack01.Push("gameItemMenu");
        while (stack01.Count > 1)
        {
            Debug.Log(stack01.Pop());//��ջ
        }
        Debug.Log(stack01.Peek());//ֻȡ��ֵ������ջ

//����
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("name");//���
        queue.Dequeue();//����
        queue.Peek();//ֻȡ��ֵ��������
```
- ���ּ��ϣ�

||�Ƿ���|����|�ص�|ʹ��Ƶ��|
|---|---|---|---|---|
|�б�|ArrayList|List<T>|����ͨ��������ȡֵ|��|
|�ֵ�|Hashtable|Dictionary<TKey,TValue>|����ͨ����Key��ȡֵ���������ظ���s����ֵ�����Ͳ����ޣ���ʵ��Ӧ����**���ƺ������ַ�������ʽ**|��|
|ջ|Stack|Stack<T>|����ȳ�||
|����|Queue|Queue<T>|�Ƚ��ȳ�|

##### tips
�˵�������ķ���˳�򣬿���ʹ��ջ�洢


##### tips ��̬������

��ͼ����һ����̬������ʱ�����췽��ӦΪ��̬�������ڵĹ�������ҲӦΪ��̬�������ڷ���Ϊ�Ǿ�̬�ģ���÷�����Ҫ����ʵ����������ʹ��

```C#
        private static Dictionary<string, Texture> cloths;
        static  ResourceManager() { 
            cloths=new Dictionary<string, Texture> ();
        }

        public static Texture LoadCloth(string name) {
            return Resources.Load<Texture>("Texture_Game03/"+name);
        }
```


## �ļ�ϵͳ��IO

�����������ռ� System.IO

#### DriveInfo��������Ϣ��

```csharp
        DriveInfo[] infos=DriveInfo.GetDrives();
        foreach (DriveInfo info in infos)
        {
            Debug.Log(info.Name);
        }
```

#### File��FileInfo

- FIleInfo���Ի�ȡ�ļ���Length���ԣ���һ���ļ����ֽڳ���
  - ʹ��ʱ��Ҫ��ʵ����һ��FileInfo

```c#
        string filePath = "F:/aa/bb/samplefile.docx";

        //FileInfo
        FileInfo fileInfo = new FileInfo(filePath);
        Debug.Log(fileInfo.FullName);//F:/aa/bb/samplefile.docx
        Debug.Log(fileInfo.Name);//samplefile.docx
        Debug.Log(fileInfo.Length);
        Debug.Log(fileInfo.DirectoryName);//F:/aa/bb
```

- File ʹ���侲̬�������ļ����д������ƶ������ơ�ɾ��

```c#
        string filePath = "F:/newfile.txt";
        if(File.Exists(filePath))File.Delete(filePath);
        else File.Create(filePath);
        if (File.Exists(filePath))
        {
            string nfilePath = "F:/aa/bb/file.txt";
            File.Move(filePath, nfilePath);
            //File.Copy(filePath, nfilePath);
        }
```
- File.Create(filePath) **���ܿ缶����**�������ļ��в�����ʱ���޷������´����ļ��������ȴ����ļ��У��ٴ����ļ�

- File ��д�ļ�
  - ��Ҫ���ڶ�д�����ļ�
    - �����ļ�Config����StreamingAssets�ļ����£�**��Ϸ����ʱStreamingAssets�ļ��в��ᱻ���**���ʿ�������Ϸ���������ͨ���޸�config���޸���Ϸ�еĲ���ֵ����UI���������������ȡ� 
����ͨ��Application.StreamingAssetsPath��ȡ���ļ��е�·������ʹ��Path.Combine()ƴ�ӻ�������ļ�������·��
    - ע�⣺File��Write***()����д���Ǹ���д�룻����Ҫ׷��д�룬��ʹ��Append***()��������`File.AppendAllLines()`��
```C#
    private void ReadWriteDemo()
    {
        //��ȡ�ı�
        string path = "f:/aa/file.txt";
        string text=File.ReadAllText(path);//���ļ���ȫ���ı���ȡΪһ���ַ���
        Debug.Log(text);
        string[]texts=File.ReadAllLines(path);//���ļ���ȫ���ı����ж�ȡΪһ���ַ����б�
        foreach(string s in texts)Debug.Log(s);

        //��ȡ�ֽڣ���ͼ����Ƶ�ȣ�
        Byte[]bytes=File.ReadAllBytes(path);

        //д�ı�
        string path02 = "f:/aa/nfile.txt";
        //File.WriteAllText(path02, text);
        File.WriteAllLines(path02, texts);
        //д�ֽ�
        File.WriteAllBytes(path02, bytes);
        //׷��д��
        File.AppendAllLines(path02, texts);
    }
```

#### Directory��DirectoryInfo

Directoryʹ�þ�̬���������ļ��д�����ɾ������ȡ��Ŀ¼�ȣ�DirectoryInfo��Ҫ��ʵ������ʹ��

```c#
        string path = "F:/aa/bb";      
        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);
        //Directory.Delete(path);//��·��Ϊ���ļ���ʱ����ɾ��
        //Directory.Delete(path, true);//�ݹ�ɾ����·���������ļ��к��ļ�
        string[]fileNames=Directory.GetFiles(path);//��ȡ·���µ������ļ�������·�������ܻ�ȡ���ļ��е��ļ�·����
        string[] dire=Directory.GetDirectories(path);//��ȡ·���µ��������ļ�������·��
        foreach (string file in fileNames) Debug.Log(file);
        foreach(string dir in dire) Debug.Log(dir);
```

ע�⣺
- Directory.Delete(path);
  - **��·��Ϊ���ļ���ʱ����ɾ��**
- Directory.Delete(path, true);
  - **�ݹ�ɾ����·���������ļ��к��ļ�**
- Directory.CreateDirectory(path);
  - **���Կ缶����Ŀ¼**����Ҫ����·��"F:/aa/bb"����û��aa�ļ��У��������ֱ�Ӵ���aa�ļ����ٴ���bb�ļ���

#### Path ·����
- ���ڴ���·���ַ���
- ��Ϊ��̬����

```c#
        string filePath = "F:/aa/bb/samplefile.docx";
        Debug.Log(Path.GetFullPath(filePath));// F:/aa/bb/samplefile.docx
        Debug.Log(Path.GetDirectoryName(filePath));// F:/aa/bb
        Debug.Log(Path.GetFileName(filePath));// samplefile.docx
        Debug.Log(Path.GetFileNameWithoutExtension(filePath));// samplefile
        Debug.Log(Path.Combine("F:", "bb", "cc", "dd"));// F:bb\cc\dd
```

###### ʵ��

1. �����ļ�����·�������ļ�

```c#
    /// <summary>
    /// �����ļ�
    /// </summary>
    /// <param name="filePath">�ļ�������Ŀ¼</param>
    private void CreatFileDemo(string filePath)
    {

        if (!File.Exists(filePath))
        {
            string floderPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(floderPath))
            {
                Directory.CreateDirectory(floderPath);
            }
            File.Create(filePath);
        }
        else Debug.Log("**�ļ� " + filePath + " �Ѵ���");
    }
```

2. �����ļ�����·���ƶ��ļ�

```C#
    /// <summary>
    /// �ƶ��ļ�
    /// </summary>
    /// <param name="fromPath">Դ�ļ�������·��</param>
    /// <param name="toPath">Ŀ���ļ���·��</param>
    private void MoveFileDemo(string fromPath,string toPath)
    {
        if (!File.Exists(fromPath)) Debug.Log("** "+fromPath + "�����ڣ�");
        else
        {
            if (!Directory.Exists(toPath))
            {
                Directory.CreateDirectory(toPath);
            }
            string fileName=Path.GetFileName(fromPath);
            //ƴ��·�������Ŀ���ļ�����·��
            string fileNewPath=Path.Combine(toPath,fileName);
            if (!File.Exists(fileNewPath)) File.Move(fromPath, fileNewPath);
            else Debug.Log("** " + fileNewPath + "�Ѵ���");
        }
    }
```
*�����ļ�ͬ�ϣ���File.Move(fromPath, fileNewPath);��ΪFile.Copy(fromPath, fileNewPath);*
*��������һ��������*

#### Stream��
ֻ�ܶ��ֽ�

```C#
    private void StreamDemo()
    {
        Stream stream = new FileStream("D:/file.txt",FileMode.Open);
        byte[] buffer = new byte[stream.Length] ;
        stream.Read(buffer, 0, buffer.Length);//�����ݴ�������������
        stream.Write(buffer, 0, buffer.Length);//�����������ݶ�������
        stream.Flush();//���������ݳ嵽�ļ���
        stream.Close();
        string text=System.Text.Encoding.UTF8.GetString(buffer);//���ֽ��������Ϊ�ַ�����UTF8Ϊ�ļ��ı����ʽ�������ļ����޸�
        Debug.Log(text);
    }
```


---

## ���ģʽ
### Unity�г��õ����ģʽ
#### ����ģʽ
��������дһЩ�����࣬����UI���棬��Ч��

���ڵ���ģʽ���������⣬��Ҫ��������������������

1. �ǲ����̰߳�ȫ(����߳�ͬʱ���ã����ܴ������ʵ��)
2. �ǲ�������ʽ���أ�ʵ�������ǵ�һ�α�����ʱ�������������ڲ�֪����������Ƿ���Ҫ����������ʱ������£����ַ�ʽ�ȽϺ���
   - ����ʽ��ָ,��ʼ��ʱ��ʵ����һ������,����������������̵���������
   - ����ʽ��ָ,����Ҫ��ʱ�����һ��ʵ����,�������������������
3. �ܲ���ͨ�������ƻ�


##### �̳�MonoBehaviour��ĵ���ģʽ
��ʵ�ֶ����ʱʹ���˵���ģʽ����һ�ַ�ʽ��ʵ����MonoBehaviour��ĵ��������ýű���Ҫ������������

�������£�

```csharp
    public class HPBarPool : MonoBehaviour
    {
        private static HPBarPool instance;
        private Queue<EnemyHPBarLogic> barlogicsPool;
        public int initCount;
        public int maxCount;
        public EnemyHPBarLogic hPBarLogicPfb;
       
        void Awake()
        {
            instance = this;
            barlogicsPool = new Queue<EnemyHPBarLogic>();
            for (int i = 0; i < initCount; i++)
            {
                //��ʼ�������
            }
        }


        /// <summary>
        /// �Ӷ���ػ�ȡһ������
        /// </summary>
        /// <returns></returns>
        public EnemyHPBarLogic GetObject() {
            //...
            return hPBarLogic;
        }

        /// <summary>
        /// ���ն��󵽶������
        /// </summary>
        /// <param name="hPBarLogic"></param>
        public void ReclaimObject(EnemyHPBarLogic hPBarLogic) {
            //...
        }

        public static HPBarPool GetInstance() {
            
            Debug.Log("instance:" + HPBarPool.instance);
            return instance;
        }
    }
```

�������ű���ʹ�øõ�����

```csharp
    public class PoolTestLogic : MonoBehaviour
    {
        private HPBarPool pool;
        private void Start()
        {
            pool= HPBarPool.GetInstance();
            Debug.Log("pool:"+pool);
        }
        //...
    }
```

###### ����زȿ�1
һ��ʼ�ڵ���ģʽ�Ľű��У�����̬��Աinstance�ĸ�ֵ���`instance=this;`������Start()�����У���
```csharp
    Start(){
        instance=this;
    }
```
�⵼����һ�����⣬�����ڽű�PoolTestLogic�г�ʼ�������poolʱ��`HPBarPool.GetInstance();`���ص�instance��null����instance��ʱ��δ����ֵ��

ԭ��Unity�������ǿ�����ýű���ִ��˳�����޷�����ִ��˳����ȷ����ֻ����ִ�����е�Awake(),��ִ�����е�Start()��
���������ΪPoolTestLogic�Ľű���Start()��ִ���ˣ���ʱHPBarPool�ű���Start()��û��ִ�У���instance��δ����ʼ������ͨ��GetInstance()������ȡ�ĵ���instance��null.

����취��**�ѵ����ű���instance�ĸ�ֵ��һϵ�г�ʼ�������ŵ�Awake()��**��ȷ�������ű���Start()�п��Ի�ȡ��������

---
��󣬻��м��仰Ҫ����һ�£���Ȼ�͵���ģʽ�Ĺ�ϵ���󣬺ٺ١�
������Ҫע��һ��Start������Awake������ִ��˳��
��������������LitJsonSample.cs��Awake�����������ReloadFamilyData����ʼ�����ݣ�ϸ�ĵ�ͯЬ���Է��֣�����һƪ�������ʼ����������Start��������ɵġ�
**֮����Ҫ����Ų��Awake�������Ϊ�������Ƿ��ʵ���ʱ�����Ա�֤����һ���Ѿ�����ʼ���ˣ���˰ѳ�ʼ�������ŵ�Awake��������ʵ����Ĵ������Start�����**
ͬ����ԭ����Singleton.cs�Ľű���DontDestroyOnLoad (gameObject);��Ҫ����Awake������������Start�����
����Awake������Start������ִ��˳�򣬿�������ű�˵����
����˵��Awake����������ű��ڳ����м���ʱ�ͻ���ã��������нű���Awake�����ĵ���˳����δ֪�ġ�Ȼ�������е�Awake����������Ϻ󣬲ſ�ʼ����Start��������Ҫע����ǣ�Start����Ҳ����һ������ִ�еģ������ڸýű���һ�ε���Update����֮ǰ���õģ�Ҳ����˵���������ű�һ��ʼ��״̬��disable�ģ���ôֱ�������enable״̬����Update������һ��ִ��ǰ���Ż�ִ��Start����������������ִ��˳����ʱ����ʱ����ĳЩBug�Ĳ���ԭ�򣡶�����ЩBug�������ѷ��֡�

�ο�����
- [[Unity3d]����ģʽ](https://developer.aliyun.com/article/464692#:~:text=1%20%E5%BD%93%E6%88%91%E4%BB%AC%E5%9C%A8%E5%85%B6%E4%BB%96%E4%BB%A3%E7%A0%81%E9%87%8C%E9%9C%80%E8%A6%81%E8%AE%BF%E9%97%AE%E6%9F%90%E4%B8%AA%E5%8D%95%E4%BE%8B%E6%97%B6%EF%BC%8C%E5%8F%AA%E9%9C%80%E8%B0%83%E7%94%A8getInstance%E5%87%BD%E6%95%B0%E5%8D%B3%E5%8F%AF%EF%BC%8C%E5%8F%82%E6%95%B0%E6%98%AF%E9%9C%80%E8%A6%81%E8%AE%BF%E9%97%AE%E7%9A%84%E8%84%9A%E6%9C%AC%E7%9A%84%E5%90%8D%E5%AD%97%E3%80%82%20%E6%88%91%E4%BB%AC%E6%9D%A5%E7%9C%8B%E4%B8%80%E4%B8%8B%E8%BF%99%E4%B8%AA%E5%87%BD%E6%95%B0%E3%80%82%20...%202%20%E5%9C%A8Awake%E5%87%BD%E6%95%B0%E4%B8%AD%EF%BC%8C%E6%9C%89%E4%B8%80%E5%8F%A5%E4%BB%A3%E7%A0%81DontDestroyOnLoad%20%28gameObject%29%3B%EF%BC%8C%E8%BF%99%E6%98%AF%E9%9D%9E%E5%B8%B8%E9%87%8D%E8%A6%81%E7%9A%84%EF%BC%8C%E8%BF%99%E5%8F%A5%E8%AF%9D%E6%84%8F%E5%91%B3%E7%9D%80%EF%BC%8C%E5%BD%93%E6%88%91%E4%BB%AC%E7%9A%84%E5%9C%BA%E6%99%AF%E5%8F%91%E7%94%9F%E5%8F%98%E5%8C%96%E6%97%B6%EF%BC%8C%E5%8D%95%E4%BE%8B%E6%A8%A1%E5%BC%8F%E5%B0%86%E4%B8%8D%E5%8F%97%E4%BB%BB%E4%BD%95%E5%BD%B1%E5%93%8D%E3%80%82,%E9%99%A4%E6%AD%A4%E4%B9%8B%E5%A4%96%EF%BC%8C%E6%88%91%E4%BB%AC%E8%BF%98%E8%A6%81%E6%B3%A8%E6%84%8F%E5%88%B0%EF%BC%8C%E8%BF%99%E5%8F%A5%E8%AF%9D%E4%B9%9F%E5%BF%85%E9%A1%BB%E6%94%BE%E5%88%B0Awake%E5%87%BD%E6%95%B0%EF%BC%8C%E8%80%8C%E4%B8%8D%E8%83%BD%E6%94%BE%E5%88%B0Start%E5%87%BD%E6%95%B0%E4%B8%AD%EF%BC%8C%E8%BF%99%E6%98%AF%E7%94%B1%E4%B8%A4%E4%B8%AA%E5%87%BD%E6%95%B0%E7%9A%84%E6%89%A7%E8%A1%8C%E9%A1%BA%E5%BA%8F%E5%86%B3%E5%AE%9A%E7%9A%84%EF%BC%8C%E5%A6%82%E6%9E%9C%E5%8F%8D%E8%BF%87%E6%9D%A5%EF%BC%8C%E4%BE%BF%E5%8F%AF%E8%83%BD%E4%BC%9A%E9%80%A0%E6%88%90%E8%AE%BF%E9%97%AE%E5%8D%95%E4%BE%8B%E4%B8%8D%E6%88%90%E5%8A%9F%EF%BC%8C%E4%B8%8B%E9%9D%A2%E7%9A%84%E4%BE%8B%E5%AD%90%E9%87%8C%E4%BC%9A%E6%9B%B4%E8%AF%A6%E7%BB%86%E7%9A%84%E4%BB%8B%E7%BB%8D%EF%BC%9B%203%20%E5%9C%A8OnApplicationQuit%E5%87%BD%E6%95%B0%E4%B8%AD%EF%BC%8C%E6%88%91%E4%BB%AC%E5%B0%86%E9%94%80%E6%AF%81%E5%8D%95%E4%BE%8B%E6%A8%A1%E5%BC%8F%E3%80%82%204%20%E6%9C%80%E5%90%8E%E4%B8%80%E7%82%B9%E5%BE%88%E9%87%8D%E8%A6%81%EF%BC%9A%20%E4%B8%80%E5%AE%9A%E4%B8%8D%E8%A6%81%E5%9C%A8OnDestroy%E5%87%BD%E6%95%B0%E4%B8%AD%E7%9B%B4%E6%8E%A5%E8%AE%BF%E9%97%AE%E5%8D%95%E4%BE%8B%E6%A8%A1%E5%BC%8F%EF%BC%81%20%E8%BF%99%E6%A0%B7%E5%BE%88%E6%9C%89%E5%8F%AF%E8%83%BD%E4%BC%9A%E9%80%A0%E6%88%90%E5%8D%95%E4%BE%8B%E6%97%A0%E6%B3%95%E9%94%80%E6%AF%81%E3%80%82%20)

##### ����ͨ�õĶ����ObjectPools
�Ľ�������Ķ���أ�������������

```csharp
    public class ObjectPools : MonoBehaviour
    {
        //����أ��ýű��������Empty GameObject��

        /// <summary>
        /// �洢���еĶ���أ�stringΪ�ö���ض�������ͨ��stringѰ�Ҷ�Ӧ�����
        /// </summary>
        private Dictionary<string, Queue<GameObject>> objectPools;
        public int initCount;
        public int maxCount;
        private static ObjectPools instance;
        [SerializeField]
        private Transform pools;
        private void Awake()
        {
            instance = this;
            pools = transform;
            objectPools=new Dictionary<string, Queue<GameObject>>();
        }

        /// <summary>
        /// �Ӷ�����л�ȡһ�����󣬲���Ϊ�ýű����ڶ����������
        /// </summary>
        /// <param name="pfb">���ڸ�Ԥ�����ȡ����</param>
        /// <returns>��ȡ�Ķ���</returns>
        public GameObject CreatObject(GameObject pfb) {
            return CreatObject(pfb, pools);
        }

        /// <summary>
        /// �Ӷ�����л�ȡһ�����󣬲�ָ��������
        /// </summary>
        /// <param name="pfb">���ڸ�Ԥ�����ȡ����</param>
        /// <param name="objectRoot">���ڷ��ö���ĸ�����</param>
        /// <returns>��ȡ�Ķ���</returns>
        public GameObject CreatObject(GameObject pfb,Transform objectRoot) {
            GameObject res;
            if (objectPools.ContainsKey(pfb.name)) {
                Queue<GameObject> pool = objectPools[pfb.name];
                if (pool.Count > 0) {
                    res = pool.Dequeue();
                    res.SetActive(true);
                }
                else
                {
                    res= Instantiate(pfb,objectRoot.position,Quaternion.identity,objectRoot);
                    res.SetActive(true);
                }
            }
            else
            {
                objectPools.Add(pfb.name, new Queue<GameObject>());
                //Queue<GameObject> pool = objectPools[pfb.name];
                //for (int i = 0; i < initCount; i++) {
                //    GameObject obj = Instantiate(pfb, objectRoot.position, Quaternion.identity,objectRoot);
                //    obj.SetActive(false);
                //    pool.Enqueue(obj);
                //}
                res = Instantiate(pfb, objectRoot.position, Quaternion.identity, objectRoot);
                res.SetActive(true);
            }
            Debug.Log("����"+ pfb.name);
            return res;
        }

        /// <summary>
        /// ���ն���
        /// </summary>
        /// <param name="obj">Ҫ���յĶ���</param>
        public void DestroyObject(GameObject obj)
        {
            string name=obj.name;
            if(name.Contains("(Clone)"))
                name = obj.name.Replace("(Clone)","");
            Debug.Log(this.name+"**"+objectPools+"**"+name);
            if (objectPools.ContainsKey(name)) {
                Queue<GameObject> pool = objectPools[name];
                if (pool.Count < maxCount) {
                    pool.Enqueue(obj);
                    obj.SetActive(false);
                }
                else
                {
                    Debug.Log(name + "����������Ѿ��ﵽ���");
                    Destroy(obj);
                }
            }
            else
            {
                objectPools.Add(name, new Queue<GameObject>());
                objectPools[name].Enqueue(obj);
                obj.SetActive(false);
            }
            Debug.Log("�ջ�" + obj.name);
        }

        /// <summary>
        /// ��ȡ�����ʵ��
        /// </summary>
        /// <returns></returns>
        public static ObjectPools GetInstance()
        {
            return instance;
        }
    }
```

###### ����زȿ�2
ʹ�������ObjectPools����ش�����ɫ����ע���ڴ�������ʱʹ����SetActive(True),���ն���ʱʹ����SetAvtive(false)

��ɫ������нű�CharacterInfo,�������£�

```csharp
     public class CharacterInfo:MonoBehaviour
    {
        /// <summary>
        /// ����ֵ
        /// </summary>
        public float hp;
        public float maxHp;
        private ObjectPools pools;

        //private void Awake()
        //{
        //    hp = maxHp��
        //}

        //���֮�������ɫ��������������٣�����ʱ�����´���һ����������������°�hp�ĳ�ʼ������Awake����Start�ж��ǿ��Ե�
        //����ʹ�ö���ش������ջؽ�ɫ����ʱ����ɫ����ʱ�ɶ���ػ��ղ����ã�������ɫʱ�Ӷ������ȡ����ɫ�����Ҽ������ʱ��Ȼ��hp��ʼ������Awake�У�hp��ʼ�����ֻ���ڳ�������ʱִ��һ�Σ��ٴδӶ������ȡ��ʱ������ִ�г�ʼ����
        //OnEable()�ڶ��󼤻�ʱ���ã����Կ��԰�hp��ʼ������������
        private void OnEnable()
        {
            hp = maxHp;
        }

        private void Start()
        {
            pools=ObjectPools.GetInstance();
        }
    }
```

���к����ɶ�������������hp��Ϊ0������������ػ��ն���
����������ֻ��һ�����󣬴�ʱ�ټ�����������ʱ����ȡ����һ�λ��յĶ��󲢼�����ö����hpֵ��ʱ��Ϊ0�������󲻷���

- ����취��
  - ����1����hp**��ʼ���������OnEnable()������**��������ÿ�δӶ������ȡ����ʱ���������һ��OnEnable,��֤ÿһ�ζ����԰�hp��ʼ��
  - ����2��ΪCharacterInfo��**ʵ��Reset()����**�����ն���ʱ���ø÷�����ʼ����Ա����
    - Reset()������MonoBehaviour�ķ�����ֱ��ʵ�ּ��ɡ�
    
[Unity�Ż�ƪ������صĴ�����ʹ�á�������ʵ�ã�]()��ƪ������˵��

1. ���ڶ�����ǲ��ý���Ϸ�����״̬����Ϊtrue��false��ʵ��Ŀ�ģ�������Щ��Ϸ������صĽű���Start����������Awake����������Ҫ�������������һ�¡������Կ���һ��OnEnable��OnDisable��
2. �ܶ����͵Ķ�������ʹ��ǰ����ĳЩ����£���Ҫ��reset�����٣����еĳ�Ա������Ҫ���óɳ�ʼֵ��������ڳ���ʵ�ֶ�����Ҫ�û�������ʱ�����������Ҫ���������������棺
�����������ģ����磬�ڴ洢����ʱ�����ã������ӳٵģ����磬�ڶ�������ʹ�ú����ã���
�����Ǳ��ع������磬���ڱ�������еĶ�����˵��͸���ģ����������ض�����ࡣ

�����ᵽ�����£�

[[��]Unity3D�ڴ�����������(Object Pool) ](https://www.cnblogs.com/mezero/p/3955130.html)

��Ӧ��ԭ�ģ�

[C# Memory Management for Unity Developers (part 1 of 3)](https://www.gamedeveloper.com/programming/c-memory-management-for-unity-developers-part-1-of-3-)

[C# Memory Management for Unity Developers (part 2 of 3)](https://www.gamedeveloper.com/programming/c-memory-management-for-unity-developers-part-2-of-3-)

[C# Memory Management for Unity Developers (part 3 of 3)](https://www.gamedeveloper.com/programming/c-memory-management-for-unity-developers-part-3-of-3-)

ǰ��ƪ�����˴�C#���Ա����Ż��ڴ��Unity3D Profiler��ʹ��

---

##### ���̳�MonoBehaviour�ĵ���ģʽ

*������*


## ����
### ���캯������������

```c#
    class Person
    {
        private int id;
        private string name;

        public Person()
        {
            id = 1;
            name = "sb";
        }

        public Person(int id)
        {
            this.id = id;
        }

        //���캯��������д��
        public Person(string name):this(1,name)
        {

        }

        //���캯����������
        public Person(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return this.id+"=>"+this.name;
        }


        /*
            �����������������͵Ķ��ڴ���������ʱ���ã�C++�г��õ�
            C#�����Զ��������ջ���GC�����Ժ��ٱ�ʹ�ã�������Ҫ��һ��������������ʱ��һЩ���⴦��
            Unity�м�����������������
         */
        ~Person()
        {
            //��������
        }


        public static void Main()
        {
            /*
                ����ʹ���޲ι��캯���������
                1.���г���Ĭ�����ص��޲ι��캯���⣬û���������캯��
                2.�������������в������캯����������ʽ��д�����޲ι��캯��
             */
            Person p1 = new Person();
            Person p2 = new Person(2);
            Person p3 = new Person("Tom");
            Person p4 = new Person(4,"marry");

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);
            Console.WriteLine(p4);
            Console.ReadLine();
        }
    }
```
### ��������

�������� GC (Garbage Collector)

GCʱ��������ѣ�Heap���϶�̬��������ж��󣬿������Ƿ����ã�δ�����õľ���������

![��������01](unityNoteAssert/��������01.png)

GCֻ������е��������գ��������ʹ��ڶ��С�

ֵ������ջ�з����ڴ棬��ϵͳ�Զ������ڴ���ա�

ע�⣺GC���������ܣ������Խ�ʡ�ڴ档�����GC���������ڴ棬�����Խ�ʡһ�������ܡ�

#### GCԭ��
![Gcԭ��](unityNoteAssert/gcԭ��.png)
### ʹ�����Ե�����
#### ͨ�����Ի�ȡ����ʱ���Խ���һЩ�߼�����

```c#
    private int age;
    public int Age {
            get { return age; }
            set { 
                if(age < 0 ) age = 0;
                age = value;
            } 
        }
```

#### ��Ա���Աȳ�Ա�������ֶΣ��и��ḻ��Ȩ�޿�������

�����ֶ���˵����Ȩ�޽������֣�3P����
- public �����ģ����Ա��κζ����ȡ���޸�
- protect �����ģ�ֻ�ܱ����������������ȡ���޸�
- private ˽�ܵģ�ֻ�ܱ������ȡ���޸�

ע�⣬3PȨ�޵Ļ�ȡ���޸���Ϊ���޷��������Ƶģ�������ֶ��ܱ���ȡ����ô��Ҳ�ܱ��޸ģ��޷�ʵ��**ֻ��**��**ֻд**��Ȩ�޿��ơ�

ʹ�����ԣ���Ա���ԣ���������ʵ��3PȨ�޿��ƣ�����ʵ��ֻ����ֻд���ơ����£�

```c#
        private int id;
        private string name;
        private int age;
        private int hash;

        //����ֻ�� ��һ
        public int Id {
            get { return id; } 
        }
        //����ֻ�� ����
        public string Name { 
            get { return name; } 
            private set { name = value; }
        }
        //�ɶ���д
        public int Age {
            get { return age; }
            set { 
                if(age < 0 ) age = 0;
                age = value;
            } 
        }
        public int Hash { 
            get { return hash; } 
        }
```




## ������
*������*
## �ӿ�
���幦��

*������*

[C#�г�����ͽӿڵ�������ʹ��](https://www.cnblogs.com/sunzhenyong/p/3814910.html)

# unity�ʼ�
��¼ѧϰ����

---

## ��Ⱦ����

## Lua

## �ȸ���

## ��������
![��������](unityNoteAssert/��������.png)
## ��ת
1. ֱ���޸�transform.eularAngle�ֶΡ�ע�⣬���ַ����޸�ʱ�����������ʾ��ֵΪ��ֵʱ������ʵֵΪ360-��ʾֵ��
2. ʹ��transform.Rotate������

### ����1
- Ŀ�������ƾ�ͷ��ת��˼·���£�
  - ʹ��Input.GetAxis()��ȡ��궯������
  - ������ֵ����ת���ٶȣ��ó�ת���Ƕ�vertical,horizontal
  - ʹ��Rotate(vertical,horizontal,0)ʵ��ת��
    - ��ʹ��eularAngle.x=EularAngle.x+vertical  
    ...  
    ʵ��
###### tips
ʹ��Rotate()ʱ���뿼��ת���������������������ỹ�����������ᡣ����дRotate(...,...,...)ָʹ�����������ᣬ��������תʱY�����ת���������󲻷���
- �������ˮƽת���봹ֱת���ֿ�����
    - Rotate(vertical,0,0);//��ֱ
    - Rotate(0,horizontal,0,Space.Word)//ˮƽ
- Ч����ˮƽת������������ϵY�ᣬ��ֱת������������ϵX��
###### tips
�ƶ�����һ�����FixedUpdate�����У���ת�������Update�У���������

### �ƶ�

###### tips
**transform.forward���ص�����������������ϵ�µ������������ǣ�0��0��1��**����transform.forwardת������������ϵ�¾��ǣ�0��0��1����
Vector3.forwadr���ǣ�0��0��1����һ�����������������ĸ�����ϵ�¶���������������������󣺿�������ת��ͳ��������ƶ����������£�
```csharp
    //ת��
    private void Rotate(float horizontal, float vertical)
    {
        if (vertical != 0 || horizontal != 0) {
            transform.forward = new Vector3(horizontal, 0, vertical);
        }           
    }
    //�����������ƶ�
    private void Move(float horizontal, float vertical)
    {
        if (vertical != 0 || horizontal != 0) {            
            transform.Translate(Vector3.forward * Time.deltaTime,Space.Self);
        }
    }
```
ע�⣬**`transform.Translate(Vector3.forward * Time.deltaTime,Space.Self);`��`transform.Translate(transform.forward * Time.deltaTime,Space.World);`Ч����һ����**���������£�
- `transform.Translate(Vector3.forward * Time.deltaTime,Space.Self);`
    - ������������ϵ�еģ�0��0��1�������ƶ���������ķ���
- `transform.Translate(transform.forward * Time.deltaTime,Space.World);`
    - transform.forward���ص�������������ϵ�µ�����������Ҫ����������ϵ���ƶ�
(Unity3D֮����ö���������������ϵ�ƶ�)[https://blog.csdn.net/qq_40664170/article/details/81750350]


---
## 3D��ѧ

### ����

**�����ȿ��Ա�ʾ�㣬Ҳ���Ա�ʾ������ʹ��ʱһ��Ҫ�����**
- ����ģ�� magnitude,����ģ����Ҫ��ƽ������һ�㲻��ƽ����ʹ��ģ��ƽ��SqrMagnitude��Ч�ʸߡ�
```C#
    float r1 = pos.magnitude;
    float r2 = pos.sqrMagnitude;
```
- ������һ����λ����ʹ��normalized��Normalize()����,ʹ����ת��Ϊ���򲻱�ĵ�λ������  
```C#
    Vector3 r3=pos.normalized;
    pos.Normalize();//�����һ��
```
```C#
    t3.Translate(r.normalized*Time.deltaTime);//t3������r�ķ����ƶ�
    t3.position += r.normalized;//Ч��ͬ��
```

#### ����2

��һ����Ϊ8������v1ת��Ϊ����Ϊ13��v2��˼·��
- ��v1��һ�� `v2=v1.normalized;`
- ����һ��������13 `v2=v2*13;`

### ���Ǻ���

|�Ƕ�Degree | ����Radian|
|:---:|:---:|
|180�� | PI|
- Unity�е����Ǻ�������ʹ�õ��ǻ��ȣ���������ֵΪ�Ƕ�ʱ��Ҫ��ת��Ϊ����
```C#
    Mathf.Sin(rad1);//����sin
    Mathf.Asin(rad1);//����arcsin
```

###### tips
- �Ƕ�תΪ����
```C#
    float deg1 = 60;
    float rad1 = deg1 * Mathf.PI / 180f;//�ֶ�ת��
    float rad2 = deg1*Mathf.Deg2Rad;//ʹ��ϵͳ�ṩ��Mathf.Deg2Rad=Mathf.PI / 180f
```
-  ����תΪ�Ƕ�
```C#
    float deg = rad * Mathf.Rad2Deg;
```

#### ����3
- ����������ǰ��30�㡢10��Զ��λ����������
```C#
    float len = 10;//б�߳�
    float deg = 30;//�Ƕ�
    float deltaX = len * Mathf.Sin(deg*Mathf.Deg2Rad);
    float deltaZ=len*Mathf.Cos(deg*Mathf.Deg2Rad);
    Vector3 pos= this.transform.TransformPoint(deltaX, 0, deltaZ);
```
###### tips
```C#
    //����������ϵ������ת������������ϵ��
    transform.TransformPoint(deltaX, 0, deltaZ);
```
### �����˷�
v1=[x1,y1,z1],v2=[x2,y2,z2]
- ������ˣ�������ڻ���
    - v1 ��� v2=x1\*x2+y1\*y2+z1\*z2
    - �������壺v1 �� v2=|v1|��|v2|cos<v1,v2>
    - ���ã���֪������������н� 
      - ���裺һ���Ƚ���������һ������ģ��Ϊ1����ʱ���ֵ��Ϊcosֵ
```C#
    Vector3.Dot(v1, v2);//�������
```

###### tips

|��������|����������|
|---|---|
|![��������](unityNoteAssert/��������.png "��������")|![����������](unityNoteAssert/����������.png "����������")|  

- ������ˣ�����������

  - ������� 
  - �������壺����� �������������ķ�����
  - �����ж�:һ��ʹ����������������unity���෴��ʹ������
  - v3=v1 X v2;|v3|=|v1 X v2|=|v1|��|v2|sin<v1,v2>
  - Ӧ��
    - ������ֱƽ�������
    - �ж����������λ�ã�����v3����

```C#
    Vector3 v3=Vector3.Cross(v1, v2);
```
###### tips

��ˡ���˾������ʹ��

### ŷ����

- ʹ�������Ƕȱ��淽��
  
  - X��Z��ת������X��Z����ת��Y����ת����������ϵ��ת 
  - �ŵ㣺
    - ֻ����������ռ�ÿռ�С
    - ����
    - �������ֲ����ڲ��Ϸ��ĸ�ֵ
  - ȱ�㣺
    - һ����λ�ı�﷽ʽ��Ψһ ���� 0��5��0 ��0��365��0
    - �����������������X����ת+-90��ʱ���֣�������360����������ת

```C#
    Vector3 v = transform.eulerAngles;
```
### ��Ԫ��

Quaternion
- ��ʾ��ת����һ����ά����x,y,z��һ������w���
- x,y,z������������ת
- ![��Ԫ��](unityNoteAssert/��Ԫ��.png)
-  ��Ԫ������Ԫ������ʾ�����ת

```C#
     Quaternion qua = Quaternion.Euler(0, 20, 10) * Quaternion.Euler(0, 30, 0);
    //qua=0,50,0
```
- ��Ԫ�������������������������Ԫ����ʾ�Ƕ���ת
```C#
//������v��y����ת30��
    Vector3 v = new Vector3(0, 0, 10);
    Vector3 nv = Quaternion.Euler(0, 30, 0) * v;//
```

- ȱ��
  - ���ڲ��Ϸ�ֵ
  - ����ʹ�ã������鵥���޸���Ԫ����ĳ��ֵ
###### tips

transform.Rotate()����Ԫ��ʵ��

#### ����4
- ����������ǰ��30�㡢10��Զ��λ����������
```C#
    Vector3 ver = new Vector3(0, 0, 10);
    ver = transform.rotation * ver;// ��������������ת
    ver = Quaternion.Euler(0, 30, 0) * ver;//��y��ת��30��
    ver = transform.position + ver;//����������ϵת������������ϵ������transformPoint
    Debug.DrawLine(transform.position, ver, Color.red);
```
```C#
//��һ��д������ֱ��ʹ��transform.forward��������ʼ�ո���������ת
    Vector3 ver = transform.forward * 10 ;// ��������������ת
    ver = Quaternion.Euler(0, 30, 0) * ver;//��y��ת��30��
    ver = transform.position + ver;
    //ver=transform.TransformPoint(ver);
    Debug.DrawLine(transform.position, ver, Color.red);
```

#### ����5

![����5ը����Χͼ](unityNoteAssert/����5ը����Χͼ.png)

���ڽ�ɫ��ը��֮��������ϰ������ɫ��ը�����������ֹ�ϵ��

- ��ɫ��ȫ��¶
- ��ɫ����ȫ��¶
- ��ɫ����¶

�ʲ��ܼ�ʹ�ý�ɫ���ĵ��жϡ�����취��ʹ��ը�����ɫ���е�����жϡ�
����е�˼·���£�

- ��֪����
    - ը�����꣨�ýű�����ը�������ϣ�
    - ������ꡢ�뾶

1. ���÷����Ǻ�������������е����ߺ�������ը�����ߵļн�
2. ���������ը�����ɵ�����������Ϊ ����ָ��ը��
3. �����һ��������Ұ뾶������Ұ뾶Ϊ����ײ���뾶��
4. ���üнǼ���Ԫ����ת3���������õ��е����ڷ���
5. ���õ��ɽ�ɫ��������ϵת������������ϵ�������е�λ��

![����5ը����Χ����ת��](unityNoteAssert/����5ը����Χ����ת��.png)

```C#
private void Demo08()
    {
        Vector3 boomPos=transform.position;
        GameObject player = GameObject.FindWithTag("Player");
        Vector3 playerPos=player.transform.position;
        float r = player.GetComponent<SphereCollider>().radius;//��ɫ�뾶
        Vector3 pToB = boomPos - playerPos;
        float dis = pToB.magnitude;
        Vector3 nPToB = pToB.normalized*r;
        float deg= Mathf.Acos(r/dis)*Mathf.Rad2Deg;//�����Ǻ������ص��ǻ��ȣ�Ҫ��Quaternion.Euler��ʹ����Ҫ��ת��Ϊ�Ƕ�
        Vector3 p1 = Quaternion.Euler(0, deg, 0) * nPToB;
        Vector3 p2= Quaternion.Euler(0, -deg, 0) * nPToB;
        //�����з���ͳ��ȡ��������������ʾ��ĳ������ϵ�£�����ԭ��ĳ������ĳ�����봦�ĵ㣬������Ҫ���������ת��
        Vector3 np1=player.transform.TransformPoint(p1);
        Vector3 np2 = player.transform.TransformPoint(p2);
        if (dis <= 50)
        {
            Debug.DrawLine(this.transform.position, np1, Color.red);
            Debug.DrawLine(this.transform.position, np2, Color.red);
        }
        else {
            Debug.DrawLine(this.transform.position, np1, Color.green);
            Debug.DrawLine(this.transform.position, np2, Color.green);
        }

    }
```

### Vector3��̬����
1. ������������֮��ĽǶȣ��Զ�Ϊ��λ����

```C#
public static float Angle (Vector3 from, Vector3 to);
```

2. ��������׼����ʹ���Ǳ˴�����������ȡ��normal����������

```C#
public static void OrthoNormalize (ref Vector3 normal, ref Vector3 tangent);
```
3. ��������vector������onNormal�����ϵ�ͶӰ

```C#
public static Vector3 Project (Vector3 vector, Vector3 onNormal);
```
4. ���ټ��ƶ�����current��target������Ϊstep��������׼ȷ����Ŀ��㡣

```C#
current.position = Vector3.MoveTowards(current.position, target.position, step);
```
5.�����ƶ�������׼ȷ����Ŀ��㣬ֻ�����޽ӽ����ʵ�����С��ĳһֵʱ��ֱ���޸�λ��ΪĿ���λ��
```C#
current.position = Vector3.Lerp(current.position, target.position, delta);
```
###### tips
Lerp��Ϊ��ֵ����Lerp��0��10��0.1�����ص���1��Update�е���ʱ��Ӧ�ı��ֵ��delta���������붼ȥ�ı�current�����ֵԭ�ⲻ�Ǻܷ��ϡ�




### Quaternion��Ԫ��

#### ����API��

1. ����һ����form����ת��toĿ�귽������Ҫ����ת
```C#
Quaternion.FromToRotation(Vector3 fromDirection, Vector3 toDirection)
```

����һ�������ĳ�����������Quaternion.FromToRotation()���API������ͼ������(m_MainTran) ��z�ᣨ��ɫ�ᣩ ����Ŀ�����壨m_TargetTran����
![��Ԫ��˵��ͼ1](unityNoteAssert/��Ԫ��˵��ͼ1.png)

�������£�
```C#
            //���Ŀ�곯��
            Vector3 targetDir = m_TargetTran.position - m_MainTran.position;
            
            //���m_MainTran.forward��ת��Ŀ�귽����Ҫ����ת��Ԫ��
            Quaternion  q = Quaternion.FromToRotation(m_MainTran.forward, targetDir);
            
            //�����������ת��Ԫ��Ӧ�õ� forward ����
            Vector3 finalDir = q * m_MainTran.forward; 
            
            //�������Ŀ��� forward �����������ķ���
            m_MainTran.forward = finalDir;
```

Ч�����£�

![��Ԫ��˵��ͼ2](unityNoteAssert/��Ԫ��˵��ͼ2.png)

�������������Ŀ���x�ᳯ��Ŀ�꣬��right���򡣿�������д��

```C#
            //���Ŀ�곯��
            Vector3 targetDir = m_TargetTran.position - m_MainTran.position;

            //���m_MainTran.right��ת��Ŀ�귽����Ҫ����ת��Ԫ��
            Quaternion q = Quaternion.FromToRotation(m_MainTran.right,targetDir);

            //�����������ת��Ԫ��Ӧ�õ� right ����
            Vector3 finalDir = q * m_MainTran.right;

            //�������Ŀ��� right �����������ķ���
            m_MainTran.right = finalDir;
```

tips: `����2D��Ϸ�����á���Ϊ2D��Ϸ����һ�����������x��y����Ŀ�ꡣ`

2. ����һ����ת��ʹ��Ŀ���������(z��)ָ��Ŀ��forward

```C#
Quaternion.LookRotation(Vector3 forward, Vector3 upwards = Vector3.up)
```
tips: `����Ŀ��ʱy�������z���Ϸ���Ҳ�������·��������õ�2���������ƣ�����Ļ�Ĭ����Vector.up�Ϸ�����ı䷽�������Vector.down��`

��Quaternion.LookRotation()����Ŀ�곯��Ŀ�귽���ϴ���:
```C#
            //���Ŀ�귽��
            Vector3 targetDir = m_TargetTran.position - m_MainTran.position;
            
            //�����z�ᳯ��Ŀ�귽����Ҫ����ת��Ԫ��
            Quaternion rotation =  Quaternion.LookRotation(targetDir,Vector3.up);
            
            //��m_MainTran.rotation�����������ת
            m_MainTran.rotation = rotation;
```

tips: `����������������ת��ʾZ�ᳯ��Ŀ�귽����Ҫ����ת��`

#### ��ת��ֵ�붯��ʵ��

1. ��ֵ
```C#
Quaternion.Lerp(Quaternion a, Quaternion b, float t)
```

tips: `��������Ԫ�������ǿ����������Quaternion.FromToRotation()��Quaternion.LookRotation()���������Ҫ�Ĳ�����`
![Lerp��ת](https://img-blog.csdnimg.cn/45f50dfd7d3d4606bf940357b23878d3.gif)

2. ����ת�� from ת�� to�� ��ת�ĽǶ�Ϊ maxDegreesDelta ����������ת���ᳬ��to. �������������������ת�Ƕȡ�Դ������Quaternion.SlerpUnclamped()������ġ�
```C#
Quaternion.RotateTowards(Quaternion from,Quaternion to,float maxDegreesDelta)
```

3. ����һ����ת��������axis������Ϊ��ת�ᣬ��תangle�Ƕȡ�
```C#
Quaternion AngleAxis(float angle, Vector3 axis)
```

��������������ǿ��������ǵķ���������������ת����Ƕȣ���ȷ�İ�������Ҫ��Ч������ת��
������2D��Ϸ�У�����һ��������Vector.forward����ת��
��3D�ռ��У����ǿ����ò���������ת�ᡣ

��˵���ѧ���壺Vector c = Vector3.Cross(a,b); �����������c��ֱ������a��b�γɵ�ƽ�档�������c��������Ҫ����ת�ᡣ
```C#
    //�����ת��
    rotAxis = Vector3.Cross(m_MainTran.forward,m_TargetTran.position - m_MainTran.position);
    //�����ÿ֡����ת
    Quaternion rotQ = Quaternion.AngleAxis(perAngel * Time.deltaTime,rotAxis);
    //Ӧ����ת
    m_MainTran.forward = rotQ * m_MainTran.forward;
```

### ����ϵ

#### WorldSpace
��������ϵ��ȫ������ϵ���������������Ĺ̶�����ϵ���ǲ���ġ�
ԭ���ǹ̶��ģ�0��0��0��

���ã���������������ʾ�����������е����꣬��**����**�ġ�

#### LocalSpace
��������ϵ���ֲ�����ϵ����������ϵ������ÿ���������ӵ�е�����ϵ�������Ŷ����ƶ�����ת���ı�λ�á�����
ԭ���Ƕ���ģ�͵����ĵ㡣

���ã����������**���**λ�ù�ϵ�������ϵ��

#### ScreenSpace

��Ļ����ϵ��������Ϊ��λ��ԭ��Ϊ��Ļ���½ǣ����Ͻ������ǣ�Scree.width,Screen.height����
![��Ļ����ϵ](unityNoteAssert/��Ļ����ϵ.png)

���ã���ʾ��������Ļ�е�λ�á�

tips��`��Ļ����ϵ��z���꣬��Ϊ�˱��ں���������ϵ����ת����z���ʾ���嵽������ľ��롣`



#### ViewportSpace

�ӿ�����ϵ�����������ϵ������Ļ���½�Ϊ��0��0�������Ͻ�Ϊ��1��1����z��ʾ���嵽��������롣

���ã���ʾ������������е�λ��

### ����ϵת��

#### LocalSpace -> WorldSpace

![����ϵת��1](unityNoteAssert/����ϵת��1.png)

#### WorldSpace -> LocalSpace

![����ϵת��2](unityNoteAssert/����ϵת��2.png)

#### WorldSpace <--> ScreenSpace

![����ϵת��3](unityNoteAssert/����ϵת��3.png)

#### WorldSpace <--> ViewportSpace

![����ϵת��4](unityNoteAssert/����ϵת��4.png)

##### ����

1. �����˶���Χ����Ļ�ڣ������Ե����Խ����Ե

```C#
    private void Start()
    {
        miainCamera = Camera.main;// ͨ��mainCamera��ǩ�ҵ������������
    }
    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        if (vertical != 0 || horizontal != 0)
        {
            Move(horizontal, vertical);
        }
    }

    private void Move(float horizontal,float vertical)
    {

        dir = ScreenPosLimit(horizontal, vertical);
        transform.Translate(dir*moveSpeed*Time.deltaTime);
    }
    /// <summary>
    /// �����˶���Χ����Ļ��
    /// </summary>
    /// <param name="horizontal">������ˮƽ����</param>
    /// <param name="vertical">�����ᴹֱ����</param>
    /// <returns>�˶�����</returns>
    private Vector3 ScreenPosLimit(float horizontal,float vertical)
    {
        //Ҳ����ʹ��ScreenSpace����ʵ��
        viewportPos = miainCamera.WorldToViewportPoint(transform.position);
        if (viewportPos.x <= 0) { 
            if(horizontal<0)horizontal=0;
        }
        if (viewportPos.x >= 1) { 
            if(horizontal>0)horizontal=0;
        }
        if (viewportPos.y <= 0) { 
            if(vertical<0)vertical=0;
        }
        if (viewportPos.y >= 1) { 
            if(vertical>0)vertical=0;
        }
        return new Vector3(horizontal, 0, vertical);
    }
```
2. �����˶�����Ļ��Ե��Խ����Ե������ҽ����ϳ��½�����������ͬ��

```C#
    private void Move(float horizontal,float vertical)
    {

        dir = new Vector3(horizontal, 0, vertical);
        transform.Translate(dir*moveSpeed*Time.deltaTime);
        //���ƶ������ж�λ��
        transform.position = ScreenPosRecycle(horizontal, vertical);
    }
    /// <summary>
    /// ������Ļ��Ե������ҽ�����������ͬ��
    /// </summary>
    /// <param name="horizontal">������ˮƽ����</param>
    /// <param name="vertical">�����ᴹֱ����</param>
    /// <returns>Խ������λ��</returns>
    private Vector3 ScreenPosRecycle(float horizontal,float vertical)
    {
        viewportPos=miainCamera.WorldToViewportPoint(transform.position);
        if (viewportPos.x <= 0 && horizontal < 0) 
            viewportPos.x = 1;
        else if (viewportPos.x >= 1 && horizontal > 0)
             viewportPos.x = 0;
        if(viewportPos.y <= 0 && vertical < 0)
            viewportPos.y = 1;
        else if (viewportPos.y >=1 && vertical > 0)
             viewportPos.y = 0;
        return miainCamera.ViewportToWorldPoint(viewportPos);
    }
```

### ��������
 ģ����ʵ�����������������Ե�����

- ��ײ��Collider**����**ѡ�� Box Collider��
  - ԭ�������٣����ܺá�
- Mesh Collider�ǽ�������ģ�͵���ײ�������������ÿһ���㣬**�������**�����ļ���
  - ������ʹ��MeshCollider����**����ѡ��Convex**���Ժϲ�͹�棬���Խ�������

#### ����Rigidbody

- ����Mass����λ�Լ�ͳһ����ʾ���������������
- ����Drag���㷺��������������԰�����������
- ������AngleDrag����תʱ�յ�������
- ��ֵInterpolate�����ڻ�����壨����������Ӵ����˶�ʱ�Ķ�����
  - None ��ʹ�ò�ֵ���л���
  - Interpolate �ڲ�ֵ���ⶶ��
  - extra������ ���ֵ���ⶶ��
- ��ײ���Collision Detection�������ƶ��ĸ�����ײʱ�����໥��͸����ײ���Ƶ��Խ��ԽӰ�����ܡ�
  - ��ɢ���Discrete����������ͨ��ײ
  - Continuous��������ײ���
  - Continuous Dynamic��������̬��⣬�����������ײ���
  - ������˵���ٶ�Ӧ���ǱȽ����ģ���ν����ֻ����Եġ�
  - **���ٶ�ȷʵ��ʱ�����ӵ���ʹ����ײ���Ҳ�޷���⵽��Ӧ��ʹ������������⡣**[���߼��](#���߼��)
- ʹ������Use Gravity���Ƿ�������Ӱ��
- Is Kinematic��ѡ�к�ǰ���岻������������ƣ�����ײ���Ա����������⣬��**�˶�������ײЧ����Ӱ��**

tips��`ʲôʱ�����ײ���������й̶��Ķ����緿�ӡ�ǽ�����ȡ�`

#### ��ײ�� 

**�Ƕ��������߽�**
1. ��ײ��������
  - ���߶�����ײ������ײ������������߽�
  - **�˶�������**�����и������

2. ��ײ����������

![��ײ����1](unityNoteAssert/��ײ����1.png)

```C#
    private void OnCollisionEnter(Collision other)
    {
    //other��ײ�����Ի�ȡ��ǰ��ײ�ĶԷ�����Ķ����
        Debug.Log(other.collider.name);
    }
```

#### ������

- Collider��ѡIs Trigger��Ϊ������
- ������û�������˶�Ч��
- ������ʹ������
  - ���߶�������ײ��Collider
  - ����**����һ��**���и���
  - ��������һ����ײ����ѡIs Trigger
- ����������

![������1](unityNoteAssert/������1.png)
```C#
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }
```
  -ע�ⴥ���������Ĳ���ΪCollider����ײ�������Ĳ���ΪCollision��

###### tips

Collision:
1. ���Ի�ȡ��ײ�ĽӴ������������

```C#
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.collider.name);
        //��ȡ�Ӵ��㼯��
        ContactPoint[] cps= other.contacts;
        //��һ���Ӵ���
        ContactPoint firstContactPoint = cps[0];
        Vector3 point=firstContactPoint.point;
    }
```

2. ��ȡ�Ӵ���ķ���
```C#
    Vector3 nor=firstContactPoint.normal;
```

###### tips

**һ����������ж����ײ����������**

###### tips

**GetComponentInChildren**
- ���Դ����������塢**��������**���������ҵ���Ӧ�����


**GameObject.GetComponentInParent**
- �˷���**���ϵݹ�,ֱ�����ҵ�**����ƥ������� GameObject Ϊֹ����ƥ��active=true�� GameObjects �ϵ������

#### ���߼��

```C#
Physics.Raycast();
```

#### ����
��������ģ��

###### tips
������Դ��Ԥ���塢��Ч�ȣ������ַ�����
1. ����public���������������ק
2. ʹ��Resources.Load���أ�
```C#
// ��Դ�������ResourcesĿ¼��
   GameObject obj=Resources.Load<GameObject>("��Դ����");
```


#### �ؽ�
**�������ڴ�����Ķ���**����ӹؽ����ʱ��ϵͳ��Ĭ����Ӹ��壨Rigidbody�������

���ͣ�

- ��������Ҷ���ؽ� Hinge Joint
  - �����ڶ��ŵ�ģ�⣬Ҳ������ģ�������Ӱڵ����塣
- �̶��ؽ� Fixed Joint
  - ����������������һ��, ���λ�ñ��ֲ��䡣��������������**û�и��ӹ�ϵ**�Ķ���ʹ��һ���˶�
- ���ɹؽ� Spring Joint
  - ����������������һ��ʹ���������ŵ��������˶���
- ��ɫ�ؽ� Character Joint
  - ģ�������ͷ�ؽڵ�����
- �����ùؽ� Confingurable Joint
  - �������ӡ�ͨ�������������������ӷ�ʽ

![�ؽ�](unityNoteAssert/�ؽ�.png)

##### ����Hinge Joint



## ����
### Animation
ʹ�ý��٣����ڶ�ʹ��Animator

1. animationʹ��CrossFade���Ŷ̶���ʱ������ֻ��10֡�Ķ���Ƭ�Σ����ܳ��ֲ��ܰ��������������ŵ����������Ҫ��������ʵ��ֻ����һ�Σ�������Ϊ��֡��̫�ٵ��µ�

    - �����ʹ��PlayQueue���ţ����԰����в���

### Macanim
#### Animator

- ���ڶ���״̬ת����Has Exit Time��
  - ���Կ���״̬ת��������������ѡʱ�������ڶ��������������������������Ž���״̬ת��
  - ����ת��û������ת������ʱ�����빴ѡ��һ����ܱ�֤��ǰ��������������ת������ִ��
- һ��״̬ת����ִ����������Ϊ�������������һ������AnyState��pickup�������ת�����ֱ�Ϊ��ͬ���������ʱ����һ��ת������������ʵ�ֶ���ת��
  - ![״̬ת��00](unityNoteAssert/״̬ת��00.png)![״̬ת��01](unityNoteAssert/״̬ת��01.png)
- ���Ҫ��һ��ת����Ҫ�������ͬʱ����ģ�����һ��ת������Ӷ��ִ������

#### ��״̬��

#### BlendTree
ͨ��һ����ֵ���ƶ������

#### ��״̬��

#### BlendTree�����
һ������ʵ���ƶ������Ļ��

[ѧϰ�ʼ�: Unity Blend Tree�����������ʹ������](https://blog.csdn.net/akuojustdoit/article/details/114332071)
##### BlendType
- 1D
- 2D Simple Directional
- 2D Freeform Directional
- 2D Freeform Cartesian
- Direct

###### 1D
1D���ֻ��һ���������������������վ�������ߵ��ܵĻ�϶������ͱȽ��ʺ�ʹ��1D��ϡ�
###### 2D
###### Direct

#### ����AnimatorLayer��AvaterMaskʵ�ֶ�������
����ʵ���磬һ����һ�߹�����Ч����������Ĳ�ͬ��λ���Ų�ͬ����������ֻ������Humanoid Avater��

���裺

- �½�AvaterMask�������֡���ͬ��λ�Ķ������ǿ���ʹ��ͬһ��AvatarMask������ͬ��λ����������ʱҪ�ò�ͬ��avatarMask;
- ��AvatarMask��Ҫ���ǵĲ�λ���������λ����![������������](unityNoteAssert/������������.png)
- Animator���½�Layer�����������AvatatMask![��������](unityNoteAssert/��������.png)
- ͨ���޸�Layer��WeightȨ�أ����ɵ����������ǵ���ʾ�̶ȡ�Ϊ0ʱ����ʾ���Ƕ���������ʾԭ������Ϊ1ʱ��ʾ���Ƕ�������ʾԭ��������ʹ��animator.SetLayerWeight()�����ڴ����п���

### �����¼�Event
�ڶ���ִ�е�ĳһ֡ʱ�����¼�����Ӷ����¼��ķ�����
1. ���ĳһ������������Edit![�����¼���Ӳ���](unityNoteAssert/�����¼���Ӳ���.png)
1. ���Event,������Ӻ���Ӷ����¼�����קȷ���¼�֡![�����¼����01](unityNoteAssert/�����¼����01.png)
1. FunctionΪ�ǰ����õķ���������������صĽű����޶�Ӧpublic�����򱨴����¼��������Դ���int��float��object�����͵Ĳ���
1. �����ɺ���apply

#### ״̬��-AnyState����״̬
ʹ�ó�������ɫ������������Ϸʤ�������ȡ��ȿ���������״̬���л����Ķ���

#### AnimatorController�ĸ���
���������Ķ���״̬���л��߼���ͬ��������Clip��ͬʱ������Ҫ�ظ�����AnimatorController�������Ӷ�������л���ֻ��Ҫ����Animator Override Controller���̳г�ʼ��controller��ʹ�÷�����
![�������̳�](unityNoteAssert/�������̳�.png)

����ControllerΪ���̳еĿ��������·�Ϊԭ�ȵĶ���clip�Լ���Ӧ����clip��

##### ����Animator Override Controller��һЩҪ��
###### Animator Override Controller��ʹ��
1. Animator Override Controller��clip�ǿ�������ʱ�ı�ģ�AnimatorController����������ʱ�ı�clip��

###### Animator Override Controller�������Ż�
��ʼ��������״̬��Խ���ӣ��̳п���������Խ�
����ɲμ�����[Unity��Animator Override����������](https://zhuanlan.zhihu.com/p/371397382)

�Ż�������
1. �������ٻ���״̬����Ҫ���̳е�AnimatorController���ĸ��ӳ̶ȣ������ٵ��ڻ���״̬����ʹ�úܸ��ӵĶ��������������澡�����ʹ�ÿ�AnimationClip��ǰ���dummy����������Ϊ����������Ҫ���̳���д�ġ�
�����������ǻ���״̬�������ϰٸ�State��Ȼ��ÿ��ֻOverride������������Ϳ���ɵ���ˡ����ǿ��Բ�ɶ��Controller���߲�ɶ��State�����ƣ��������Բ�ɶ��Animator��

2. ����������AnimationClip��Constant���ߵ�ռ�ȣ������ڵ���ѡ���н��ж���ѹ��������ͼ��
    ![�������̳������Ż�1](unityNoteAssert/�������̳������Ż�1.png)

    ���������Ⱥ�Сʱ��Ҳ�������������ľ��ȣ�����СError��ص�ֵ����������ѹ��������ı����ͺ�����Ĺؼ�֡��
    ![�������̳������Ż�2](unityNoteAssert/�������̳������Ż�2.png)

    ������Щ�����������Լ�����������������Constant���ߵ�ռ�ȣ�ͬʱ��������ڴ��ռ�á�
    �ο�[Unity�����ļ�Animation��ѹ�����Ż��ܽ�](https://zhuanlan.zhihu.com/p/353402448)
3. ʹ��Timelineϵͳ��Animator����ϰ�����Controller������һ�����壬������ʱ���еĲ����������κ�һ��Override���κ�һ���޸ģ����Ƕ��������ݼ����޸ģ��ǳ����Ӵ�Unity����Timeline��ʱ�������������⣬���ǻ���ÿ��Clipȥ�޸ĵģ����Timeline������������Ļ��ƽ��һЩ���Ǹ��������Ӻõ�ѡ��

4. ��Ǯ���֣��ٷ����Ʒ��������õ���JobSystem���̵߳ȡ�  

#### Animator����api
- public static int StringToHash (string name);�ַ���ת��Ϊhash
  - `animator.StringToHash('Base Layer.walk');`
  - ʹ��Animator��SetBool()�ȷ���ʱ��ʹ��SetBool(int id)������Ч�ʸ��ߣ��˴������id��Ϊparamater�ַ�����Ӧ�Ĺ�ϣֵ��
  - �����ÿ��paramater string��Ӧ��hash����һ���������У���Ϊ��̬����������ԭ��ɲμ�[Unity��Animator Override����������](https://zhuanlan.zhihu.com/p/371397382)��
- GetCurrentAnimatorStateInfo (int layerIndex);��ȡ��ǰ����״̬
  - ����һ�� AnimatorStateInfo���ɻ�õ�ǰ״̬�ĸ�����Ϣ
- public bool IsInTransition (int layerIndex);
  - �ж�ָ������֪��������״̬ת��

�ο�[Animator API--Unity�ĵ�](https://docs.unity.cn/cn/2022.3/ScriptReference/Animator.html)


### ��Ч
1.  ��������ЧƬ��ʱ���翪ǹ��ǽ���ϵ�Ч������ʾ����ЧƬƬ��ǽ���غϣ�������ǽ�洹ֱ������취���£�


```C#
// ��������ЧƬ��ʱ����Ϊ����Ƚ�С�����Դ����������������������غ���һ�𣬵��¿�������
            //hit.point+hit.normal*0.1f��ʹ��Ч�Ĵ���λ�������߽Ӵ��淨���ƶ�һС�ξ��룬�Ӷ����غϵ������ƶ�����
            //Quaternion.LookRotation(hit.normal)����Ч��z����ת����Ӵ��淨��ͬ���Ա�֤��Ч��ʾ����
            GameObject boom = Instantiate(boomPFB, hit.point+hit.normal*0.1f, Quaternion.LookRotation(hit.normal), boomRoot);
```


### ʹ�ô���Ƭ��

#### ����̶�ʱ��ִ��

1. ����һ��ʹ��Involve
2. ��������ʹ��Time.time��ʱ�����£�

```C#
    if (Time.time >= shotInitTime) {
        ...
        ...
        shotInitTime=Time.time+shotDeltaTime;
    }
```

###### tips

Update����Ҳ���Ա���д��������д
```C#
protected virtual void Update(){}
```
������д
```C#
protected orverride void Update(){
    base.Update();
    ...
    ...
}
```

---

### GUI
#### GUI��չʷ
GUI��Graphics User Interfa
1. ��һ��GUI��OnGUI��Unity�Դ�������򵥣�������
```C#
private void OnGUI()
        {
            GUILayout.Label("����ֵ--"+playerInfo.Hp.ToString());
            GUILayout.Label(playerInfo.gunType.ToString());
            if(GUILayout.Button("��ť")){
                ������
            }
            if(playerInfo.gunType==GunType.singleGun)
            {
                GUILayout.Label("����--"+singleGun.CurBulletCount.ToString()+"/"+singleGun.SumBulletCount.ToString());
            }else if(playerInfo.gunType == GunType.mulityGun)
            {
                GUILayout.Label("����--" + mulityGun.CurBulletCount.ToString() + "/" + mulityGun.SumBulletCount.ToString());
            }
        }
```
2. �ڶ���GUI��NGUI����GUI���
3. ������GUI��UGUI����Unity�Դ������µ�

#### �����ؼ�

**UIҲ��GameObject**

##### Canvas����

������
- ��UIԪ�ص����壬����UIԪ�ر�����Canvas֮�¡�
- Canvas����Ļ����ʾ����������ͬ
- UI��ƽ�����2D�ӽǽ��� 
- ��UI�ĳߴ��޸ģ��޸���������width��height����Ҫ�޸�����scale 
- ͬһCanvas�¿ؼ�����˳��ȡ���������˳�򣬲�ͬCanvas֮�串��˳��ȡ����Canvas���������Sort Order

���ֻ���ģʽ��
- Screen Space-overlay����Ļ����ϵ����ģʽ��Ϊ2DUI��UI��Զ�Ḳ��3D���壬UI������Ⱦ
    - ����ģʽ�������������ģʽ���Ҳ������ʱ���� 
- Screen Space-Camera����Ļ����ϵ�����ģʽ��2DUI����ʱ��Ҫ���һ����Ⱦ���������������Ч�������������Ӱ��
    - �ڽ�������Ҫͬʱ��ʾ3D��2Dʱʹ�á�3D�����ס2Duiʱ
    - ��Ҫ��ʾUI��Чʱʹ�ã���Ч��3D����
    - ��Ⱦ�����������ʹ�������������ΪӰ�����ܡ�
    ���Զ�������һ��UICamera�������������ֵ�������������������UICamera��ClearFlag����Ϊ������ȡ�����ʹUICamera�Ŀհײ���͸����
    ������UICamera���޳�����CullingMaskΪ����ʾUI���������CullingMask����ʾUI
- WorldSpace��3DUI
    - ���԰�UI����3D������棬��ʱ��Ҫ��С����Scale���ŵ��������Ұ��

##### Rect Transform:
���е�UI�������Rect Transform����Transform��**RectTransform��Transform������**

- Pos X Y Z ��weight��height��left��right�ȶ���ӳ�ؼ����ĵ����������ê���λ��
- ���ĵ�Pivot�������š���ת�����ģ���0��0��Ϊ���£���1��1��Ϊ����.����1��С��0ʱ���ĵ�������֮��
- ê��Anchors:��Ļ�ֱ��ʸı�ʱ��ȷ��UI���λ�ò��䡣��UI�����λ�õĻ�׼��
  -  ÿ��UI��������ĸ��Ǽ���Ӧ�ĸ�ê�㣬����ĸ��ǵ�λ�ø���ê��
  -  ��Ļ�ֱ��ʸı�ʱ�����ê������Ļ�е����λ�ò��䣬��ê����ԭ��Ļ���Ͻǣ���ֱ��ʸı��ê����Ȼ�����Ͻ�
  -  **λ������Ӧ**������ĸ�ê�㲻�ֿ����ƶ�ʱһ���ƶ�����ʱUIͼƬ�����ֿ��Ը�����Ļ�ֱ��ʸı���Զ�����λ��
  -  ��С����Ӧ������ĸ�ê��λ�÷ֿ����ã������С����Ļ�����仯������Ļ������Ҫ����С����Ӧ
     
ê�����ã����������п���ֱ���趨��λ�ã���סShift��alt��ͬʱ�������ĵ��λ��

![ê������](unityNoteAssert/ê������.png)

�����ȡ���޸�RectTransform����ϸ���Բμ�Unity�ĵ�[Unity API��RectTransform](file:///E:/Unity%20download/UnityDocumentation/ScriptReference/RectTransform.html)

![ê���ĵ���Դ](unityNoteAssert/ê���ĵ���Դ.png)
```C#
        Debug.Log(rectTransform.position);//��transform.postionЧ��һ����������������
        Debug.Log(rectTransform.rotation);//ͬtransform.rotation
        Debug.Log(rectTransform.anchoredPosition3D);//���ĵ����ê���λ�ã���Pos X Y Z
        Debug.Log(rectTransform.anchorMin);//ê���븸�����������λ��
        Debug.Log(rectTransform.anchorMax);//ê���븸�����������λ��
        Debug.Log(rectTransform.rect.width);//UI�Ŀ��
        Debug.Log(rectTransform.rect.height);//UI�ĸ߶�
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,10);//����UI�Ŀ�ˮƽ��
        //��ͬ��ê�㲼����ʽ�� Tect Transform���Ĳ�����ʾ��Ҳ��һ����������һ���򵥵�UI�Լ�����һ��
```


##### Image���

- ���ã���ʾͼƬ��ͼƬ��Դ�뽫TextureType���͸�ΪSprite���ٽ�����ק������ʾ��
  - ���뵭��Ч������ͨ���ı�Color��RGBA��Aֵʵ��
  - ImageType���ͣ�����ΪFill����ʾ�����̡����ø����ͣ����޸�FillAmount����ʵ�ּ���cdЧ�������£�
- ![Image Type Fill����Ч��](unityNoteAssert/ImageTypeFill����Ч��.png)
- ![Image Type Fill��������](unityNoteAssert/ImageTypeFill��������.png)
- Set Native Size�����Image����µ�Set Native Size��ť������ͼƬԭʼ�ĳߴ�����ͼƬ�Ŀ��ߣ�
�����Image�������```this.GetComponent<Image>().SetNativeSize();```

![Image����](unityNoteAssert/Image����.png)


##### Text�ı�

- Text���������ı�����ʾ�������ֺ��޹أ����ֺ�̫�����̫Сʱ�޷���ʾ�ı�
- �ֺŵ���FontSize
- ��ѡRichText���ı���ǣ��ı��в������ּ���html��ǩʹ֮��������ʽ����Ӵ֡�б�塢����ɫ�ȣ�
![���ı��﷨](unityNoteAssert/���ı��﷨.png)![���ı�Ч��](unityNoteAssert/���ı�Ч��.png)

##### Button��ť

- Interactable��ѡ��ʱ�ð�ť���Խ�����ȡ����ѡʱ�ð�ť���ܽ�����������ۿ��Ծݴ˱仯�����¡�����ɼ����İ�ť����ʹ��һ�κ���ʱ����Ҫ�ٴα��棬�ʽ���ȡ������������������������ɽ���ʱ������
  - ![��ťȡ������](unityNoteAssert/��ťȡ������.png)
  - ע�⣺ȡ�����������Button���Ч����������ֱ�ӽ���Button�������������������״̬�޲��
- Transition������������
    - Color Tint����ť���ڲ�ͬ״̬ʱ�ı���ɫ
    - Sprite Swap����ť���ڲ�ͬ״̬ʱ��ʾ��ͬͼƬ
    - Animation:��ť���ڲ�ͬ״̬ʱ���Ŷ���
- - Navigation������һ������ΪNone
- **��������UI�������������Interactableѡ��**
##### Toggle��ѡ��

##### Slider����
������������Ѫ���ȣ���ʱInteractableѡ��ȡ����ѡ

###### ʹ��Slider�����������Ѫ���ķ���

- Canvas���½�һ��Slider���������Ϊhpbar����ɾ����Handle Slide Area���������½������岢���slider���������װһ��������)![Ѫ������08](unityNoteAssert/Ѫ������08.png)
- ����hpbar��Rect Transform���޸���ߴ絽���ʴ�С������Ҫ�޸�Scale

![Ѫ������07](unityNoteAssert/Ѫ������07.png)

- �޸�background
  - �޸�rect transform![Ѫ������02](unityNoteAssert/Ѫ������02.png)
  - ���ñ���ͼƬ����ɫ������ɾ���˱���ͼƬ��ֻ������ɫ����ʾѪ����
- �޸�Fill Area��rect transform![Ѫ������04](unityNoteAssert/Ѫ������04.png)
- �޸�Fill
  - �޸�rect transform![Ѫ������05](unityNoteAssert/Ѫ������05.png)
  - ���ñ���ͼƬ����ɫ![Ѫ������06](unityNoteAssert/Ѫ������06.png)

##### Scroller������

##### DropDown�����˵�


#### Canvas�������Ⱦģʽ����Ļ����

������canvas���� UI ��������������� UI Ԫ�ض���������ڻ����С���ͺñ��ǵ�ӰĻ�������е�Ӱ����Ļ���ϳ��֡�

�����Ĵ��ڣ������ǿ��Խ�һЩͨ�õ� UI ���÷ŵ������������ã����磺

��������Ϸ������������ʲô���Ĺ�ϵ������Ⱦģʽ��
���ڲ�ͬ�ֱ��ʵ���Ļ��������ν������䣿���������� Canvas Scaler��
������Щ���⣬�����������������ṩ�˶��������������䲻ͬ������

##### ��Ⱦģʽ
��Ⱦģʽ�����˻����볡����������������Ⱦ�ϵĹ�ϵ����Ⱦģʽ��ע�����������⣺


1. ������Ļ�ռ���Ⱦ������ȫ�ֿռ���Ⱦ��

    ����ʵ�еĳ�������������Ļ�ռ���� google �۾��еĽ��棬����������ʵ��������ô�߶����۾����涼��������ǰ���֣���ȫ�ֿռ䣬�����̳���Ĵ�����棬��������߶�����Ļλ�ò��䣬�����������г��ֵ�Ч�����ϱ仯��

2. �Ǹ�����������Ϸ����֮�ϣ����Ǹ����������Ұ������Ⱦ��

    ����ģʽ�£����ǲ���Ҫ�������������������������ǻ�����Ļ�����֣������ģʽ�£��������Ϊ�����̶������������ĳ����λ�ϣ�������ƶ�ʱ������������λ�ñ��ֲ��䡣



- ����Ļ�ռ���Ⱦ���Ҹ�����������Ϸ����֮�ϣ����� Screen Space - Overlay ģʽ
- ����Ļ�ռ���Ⱦ���Ҹ����������Ұ������Ⱦ������ Screen Space - Camera ģʽ
- ��ȫ�ֿռ���Ⱦ����һ���Ǹ����������Ұ������Ⱦ�ģ��� World Space ģʽ


��Ⱦģʽ�������� Canvas ����� Render Mode ѡ���У�

![��Ⱦģʽ����](unityNoteAssert/����.png)


������������һЩ������İ���������������Ⱦģʽ��

�ԡ������ﴫ˵����Ұ֮Ϣ��������չʾѪ�����¶ȡ�������������Ӣ�ܼ��ܵȵ� HUD���ʺ�ʹ�á���Ļ�ռ� - ����ģʽ����

![������ʾ��](unityNoteAssert/������ʾ��.png)

���������У���Ϸ�����ڱ���ǰ��������ʳ����ϸ��Ϣ���󷽣��ⲿ�ֻ������ʺ�ʹ�á���Ļ�ռ� - �������ģʽ���²������Ҫ���㻭����һ����Ϊ����������Ϸ����󷽣�һ����Ϊ��Ϣ��壬����Ϸ����ǰ����

![������ʵ��01](unityNoteAssert/������ʵ��01.png)

����ս2���У����Կ���ӥ���Ϸ��и���ɫ����Ļ����Ļ����һЩ���֡����ֳ������ʺ�ʹ�á�����ģʽ����

![��սʾ��](unityNoteAssert/��սʾ��.png)

##### ��������

����������Ļ�ռ�����Ⱦʱ�������ߴ�һ��������������Ļ�ߴ��𣿵����߲�һ��ʱ������ô�������ţ�

������������Canvas Scaler ��������ṩ����������ģʽ�����䲻ͬ������

1. Constant Pixel Size���ڴ�ģʽ�£�UI Ԫ�صĴ�С������ Canvas ������Ӱ�죬���Ǳ��̶ֹ������ش�С������ģʽ��������Ҫȷ�� UI Ԫ���ڲ�ͬ�豸�ϵĴ�С����һ�µ������
2. Scale With Screen Size���ڴ�ģʽ�£�UI Ԫ�صĴ�С������ Canvas �����ű����������ţ�����Ӧ��ͬ�ֱ��ʵ��豸������ģʽ��������Ҫ�ڲ�ͬ�ֱ��ʵ��豸�ϳ���һ�µ� UI ���ֺ��Ӿ�Ч���������**���ã�**
3. Constant Physical Size���ڴ�ģʽ�£�UI Ԫ�صĴ�С��������Ļ�������С�������ţ���ȷ�� UI Ԫ���ڲ�ͬ�豸�Ͼ�����ͬ�������С������ģʽ��������Ҫȷ�� UI Ԫ���ڲ�ͬ�豸�Ͼ�����ͬ�������С�������������ʹ�ô�����Ļ���豸�ϡ�

- Ϊʲô�� Constant Pixel Size ������Ҫ Constant Physical Size ��
    - ��Ϊ��ͬ�豸�ϵ� 1 ���أ�ʵ�ʴ�С�ǲ�ͬ�ģ�ʵ�ʴ�С�����豸���رȣ�DPR����ÿӢ�����أ�PPI����ͬ�����ġ�

ԭ�����ӣ�[Unity Canvas �����⣺��Ⱦģʽ����Ļ����](https://zhuanlan.zhihu.com/p/643275125)

##### ������Ļ���ţ�Scale With Screen Size��������ģʽ

�Ƚϳ��õ��Ǹ�����Ļ���ţ�Scale With Screen Size������������ģʽ��

1. ƥ���Ȼ�߶�(Match Width or Height)
�Կ��Ϊ�ο����Ը߶�Ϊ�ο����������֮���ֵ�����Ż�������

2. ����(Expand)
ˮƽ��ֱ��չ����������˻����Ĵ�С��Զ����С�ڲο���

3. ����(Shrink)
ˮƽ��ֱ�ü�����������˻����Ĵ�С��Զ������ڲο���

���������г��õķ�ʽ��**������Ļ��С���䣬�����ê��**���������㳣�õ�UI���䣻
�����Ŀ�����ǳ�����Ļ�����Կ��Ǹ߶�ƥ�䣻 �����Ŀʹ�û�����һ���ķֱ��ʷ�Χ�ڣ����Կ���ƥ��߿�0.5�ķ�ʽ���������ۣ�
�����������Կ��Ǻ㶨����ģʽ�ͺ㶨��������ģʽ��Ч���ԱȲμ�
[ԭ������](https://blog.csdn.net/qq_33789001/article/details/117781577)

---
#### UGUIͼƬ�����Ż�

- �Ż�ԭ��ʹ�õ�Sprite����Խ�٣�DrawCallԽ�٣�����Խ�á�����Ҫ��ʹ�õ�СSprite�ŵ�һ�Ŵ�Sprite�У�ʹ��ʱImageʹ�ô�sprite��һ���֡�
   - ע�⣺���Image���ʹ��ͬһ��Spriteʱ����Ϊʹ�õ�Sprite����Ϊ1 ��

![Ugui�����Ż�ԭ��](unityNoteAssert/ugui�����Ż�ԭ��.png)

- �Ż�����һ��Sprite Pack������
  - ͬ���͡���ʽ��Sprite�ſ��Դ����һ��

![������](unityNoteAssert/������.png)

- �Ż���������ʹ��ͼ���������������

![�Ż�������ͼ��](unityNoteAssert/�Ż�������ͼ��.png)

---
#### 2048UI����

1. Game��������ʾ�豸�ķֱ��ʻ����
2. ���Canvas������canvas scaler��UI scale modeΪscale with screen size������Ļ�ߴ�����
3. �޸�referencce resolutionΪ��ʾ�豸�ֱ���
4. ��canvas�����panel���������Ϊgamecontroller
   - panel��壺���Է�������UI���������ͨ���ƶ�panel���������panelʵ��UI�������ʾ����
5. gamecontroller���layout���Grid layout group��ʵ����������UI�����񲼾֣���gamecontroller��grid layout group�������������ʵ�ֲ���
   - pad��䣺ָpanel��Ե������������С����
   - cell size��ÿ����Ԫ��ߴ�
   - space����Ԫ������ 

###### tips
��UI�����ó������ɣ�����UIʹ��Ԥ����

#### Event�¼�

����¼������ַ������༭������ק�󶨣�AddListenerʹ�ô���󶨣�ͨ��ʵ�ֽӿڰ�
##### �ڱ༭������ק�󶨣�����ʹ�ã�
- ����˴�+�ţ���ק���ؽű��Ķ��󣬼���ѡ������Ҫ���õķ���![ʱ�� Event01](unityNoteAssert/ʱ��Event01.png)
- ���Թ��ظó������������ֻҪ�ö����ж�Ӧ�Ľű����
- �÷������õķ������Դ��в���������������������
- �ŵ㣺���㡣ȱ�㣺�޷���֪�÷������ĸ��������
##### AddListener��ʹ�ô����
- �ŵ㣺���׵�֪���ĸ��������
- ���裺��ΪButton���Ϊ�� 1.��ĳ������Ľű��л�ȡĿ����󣬻�ȡ�������������Button 2.��ȡʱ�䷽������OnClick() 3.��Ӽ�����AddListener
  - ��������

```C#
    Button btn=GameObject.Find("Button").GetComponent<Button>();
    btn.onClick.AddListener(MyButtonFunction);
``` 
- �е�����󶨵ķ��������в������еı����в������ɿ����Ӧ��AddListener����
##### ʵ�ֽӿ� ��
- �ű�������Ҫ�����¼��Ķ����ϡ��ö��������Խ������ߣ���**�ö�����ĳ�����ѡ��Raycast Target**����Image����������޷��������ߡ���ѡ�����ȡ����ѡ��
- ����EventSystem���� �ö������EventSystem������ҹ���������ģ�� **Input Modul����Standalone Input Modul�������������룬Touch Input Modul ����������
- ����������UnityEngine.EventSystems�����ռ䣬ʵ�ָ������ռ��ڽӿڵķ�����
- ʹ�ò��裺1.�½��ű� 2.�ڽ������м̳���Ӧ�࣬��IPointerClickHandler 3.ʵ�ֽӿڷ��� 4.���ýű����ص�ĳ��UI������
  - ʵ������һ������Ŀ�ģ�˫�������debug���

```C#
using UnityEngine;
using UnityEngine.EventSystems;
public class EventDemo : MonoBehaviour, IPointerClickHandler
{//�̳нӿ�IPointerClickHandler������Ҫʵ�ֽӿ��ڵķ���void OnPointerClick(PointerEventData eventData);
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2) Debug.Log("eventData.clickCount==2");
    }
}
```

  - ʵ�������������Ŀ�ģ������ק���������ק���������ָ��λ��ʼ����ͼƬ����ק��ʼʱ�ĵ��λ��

```C#
public class EventDemo : MonoBehaviour, IDragHandler,IPointerDownHandler
{
    private RectTransform rect;
    private Vector3 delta;
    private void Start()
    {
        rect = (RectTransform)transform;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //ָ����ʱ��¼���λ�ã��������λ����ͼƬ���ĵ����λ��delta
        //eventData.positionΪ���������Ļ����
        Vector3 tmpPos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out tmpPos);
        delta = tmpPos - transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos;
        //UI��Ļ���� ת��Ϊ��������
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rect, eventData.position, eventData.pressEventCamera,out pos);
        //����ͼƬ��ָ�����λ�ò���
        transform.position = pos-delta;
    }
}
```
###### ���ڿ�ʵ�ֵĽӿڣ�
   <li><code>public interface IEventSystemHandler(PointerEventData)</code>: �����¼������Ƚӿ�</li><li><code>public interface IPointerEnterHandler(PointerEventData)</code>: �����¼�, Ҳ�����������״ν����������</li><li><code>public interface IPointerExitHandler(PointerEventData)</code>: �뿪�¼�, Ҳ�����������״��뿪��������</li><li><code>public interface IPointerDownHandler(PointerEventData)</code>: �����¼�</li><li><code>public interface IPointerUpHandler(PointerEventData)</code>: ̧���¼�</li><li><code>public interface IPointerClickHandler(PointerEventData)</code>: ����¼�, ����ʱ�䰴����̧��</li><li><code>public interface IInitializePotentialDragHandler(PointerEventData)</code>: �ҵ����϶������, ������ʼ�϶�֮ǰ���¼�, �����϶�������ֻ����һ��</li><li><code>public interface IBeginDragHandler(PointerEventData)</code>: ��ʼ�϶��¼�, �����϶�������ֻ����һ��</li><li><code>public interface IDragHandler(PointerEventData)</code>: �϶��¼�</li><li><code>public interface IEndDragHandler(PointerEventData)</code>: ֹͣ�϶��¼�, �����϶�������ֻ����һ��</li><li><code>public interface IDropHandler(PointerEventData)</code>: �϶����ſ��¼�, Ҫ��ſ���ʱ����껹�����϶��������ڲ�, ���ͬʱҪ�������¼�(<code>IPointerClickHandler</code>)���޷��������¼�</li><li><code>public interface IScrollHandler(PointerEventData)</code>: �����¼�</li><li><code>public interface IUpdateSelectedHandler(BaseEventData)</code>: ����ѡ���¼�, ����ÿ֡����</li><li><code>public interface ISelectHandler(BaseEventData)</code>: �л�ѡ���¼�, ÿ���л�ѡ��ʱ��ѡ�еĶ�����</li><li><code>public interface IDeselectHandler(BaseEventData)</code>: ȡ��ѡ���¼�, ÿ���л�ѡ��ʱ��ѡ�еĶ�����</li><li><code>public interface IMoveHandler(AxisEventData)</code>: �����ƶ��¼�</li><li><code>public interface ISubmitHandler(BaseEventData)</code>: �����ύ�¼�</li><li><code>public interface ICancelHandler(BaseEventData)</code>: ����ȡ���¼�</li>

##### �Զ�����
����

---
### iTween

UI����ʵ�֣�iTween DoTween
�ĵ����ӣ�[iTween�ĵ�](http://pixelplacement.com/itween/documentation.php)
���ù��ܣ�![Itween���ù���](unityNoteAssert/itween���ù���.png)
- iTween ��UI����ʮ�ַ��㡢����Ч�ʸߣ��������ܵ�
- itween��Ч������ͨ���ֶ��༭����AnimatioCurveʵ�֣����ַ�ʽ���ܺã�������Ч�ʵ�

### �־û�����
�洢���ݣ���ʹ���ݳ־ã����Ա�����ظ���ȡ�޸ġ�
- Unity�ṩ**PlayerPrefs**������**�����û���ƫ������**�������ô�ʵ�����ݳ־û�
  - ԭ���Լ�ֵ����ʽ����������һ�������ļ���
  - ֻ֧�������������ݣ�int floa string
    - ��Ȼֻ֧�����������ͣ������������������洢�������͵����ݣ�Ȼ����PlayerPrefs�洢�����������֣��Դ�ʵ�ֶ����������͵�����
  - PlayerPrefs�����ݴ洢���˵��Ե�ע�����
  - ע������ֵ�ǿ����޸ĵġ������ҵ��Ǹ����ݣ�ֱ��˫���Ϳ��޸ģ�����ʹ��PlayerPrefs�洢�ؼ�����ʹ�����ʵġ�
  - ����Ȼ�������ʺ������洢��Щ��ʹ��ʧ��Ҳ����ν�����ݡ�
    - **��ҵ�ƫ������**�������������� �Ƿ�ȫ��������ѡ�
    - һЩ�򵥵����ݡ�������ҵĵ÷��б�
    - ��������Ϸԭ��ʱ��ʱ�����ݴ洢��
  - ��֮��PlayerPrefs��Ƶĳ��ԾͲ���Ϊ����������Ҵ浵�������

[PlayerPrefs���](https://developer.unity.cn/projects/61aa4006edbc2a0020e03141)

ʵ����
```C#
public class learn03 : MonoBehaviour
{
    private int num;
    private void Start()
    {
        num = 0;
        if (PlayerPrefs.HasKey("score")) num = PlayerPrefs.GetInt("score");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("click and count")) num++;

        if (GUILayout.Button("save count and load scene1"))
        {
            PlayerPrefs.SetInt("score", num);
            SceneManager.LoadScene(1);// ���������³��������³������Կ��Զ�ȡ������
        }
        GUILayout.Label("score: " + num);
    }

}
```

ʵ��������PlayerPrefs�������ģ�͵ķ�װ��ͼ�����ߵ�ǰ����
```C#
//�޸ķ�װ��ͼ���Ĵ��롣
    public Texture cloth;
    private MeshRenderer clothRender;
    //�޸�meshrender�²��ʵ���ͼ����
    clothRender=GetComponentInChildren<MeshRenderer>();
    clothRender.material.mainTexture = cloth;
```

- �޸ĵ�ǰ�����ķ�����
    - ͨ�������������󼤻�����ã�������ɾ�����壬ʵ�������л�
    - �޸Ķ����meshfilter�Ͳ�����ͼʵ�������л�
    - �� **ֻ��Ҫ�޸�ͼ��ʱ���޸�meshrender�²��ʵ���ͼ���ɣ���Ҫ�ı���״ʱ������Ҫ�ı䲻ͬ������߸ı�����meshfilter**



### �����л�

1. �����л��ĳ��� File-Build Setting������л��ĳ����б�
2. ʹ�ô����л�

![��ӳ����б�](unityNoteAssert/��ӳ����б�.png)


### ���߼��

#### �������Ļ��������

ʹ��` ray = mainCam.ScreenPointToRay(Input.mousePosition) `�ɻ�ȡ�����������������򷢳������ߣ�����` Input.mousePosition `Ϊ�������Ļ�ϵ��λ��
��ʹ��` Physics.Raycast(ray, out raycastHit) `��ȡ���߻��е�ľ�����Ϣ

[���Unity�е����������߼��](https://blog.csdn.net/weixin_43147385/article/details/124179148)

ע�⣺Ҫ��ȡraycastHit��collider�򱻻��ж��������collider��Ҫ��ȡraycastHit���ж����rigidbodyͬ��
```C#
    private Ray ray;
    private RaycastHit raycastHit;
    private Camera mainCam;
    void Start()
    {
        mainCam=Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            ray = mainCam.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out taycastHit);
            if (raycastHit.collider != null && raycastHit.collider.gameObject.name == "Cube") {
                //...
            }
        }       
    }
```
������������߼���layer mask�����ò�ǰ���������ڵ�����ʱ�����߻ᴩ�����ڵ�����ֻ���б����Ĳ�

###### ��Ҫ����

������һ�ֳ�����ʹ�����߼�⣺

**����������һ�����壬��������collider,��������collider��**

```
Debug.Log(hit.collider.name+"***"+hit.transform.name);`hit.collider.name�õ��������߻��е���ײ��
```
**hit.collider.name �������߻��е�����������֣���hit.transform.name�������߻��е�������ĸ���������֣�**



###### tips

һ��ʼ�����ַ�����ʵ�� ��Ļ�������ĳһ������ı�������ɫ�����������߲���������Ƿ�������塣
֮��֪���� onMouseDown����������MonoBehaviour��ľ�̬��������������������ϵ��ʱ���ø÷�����ע���������������collider��


#### ���ߵ���������

- Physics.RaycastAll();���������������е�hit���������е�һ������󲻻�ֹͣ���ᴩ͸���������к�������
- ע�⣬Physics.Raycast();���е�һ��������ֹͣ�ˣ���ֻ�ܷ���һ��hit

```
    private RaycastHit[] hits;
    hits = Physics.RaycastAll(mainCam.transform.position, mainCam.transform.forward, 5);
    foreach(var hit in hits){
        //...
    }
```

- Physics.OverlapSphere();���η�Χ����ײ��

```
            Collider[]colers=Physics.OverlapSphere(mainCam.transform.position, 1, enemyLayer);
            foreach (Collider col in colers)
            {
                //...
            }
```

### Э�� Coroutine

- Э�̿����ж����ںͳ��ڣ�������Э��ʵ���κη�����
- Э���ʺ�ʵ�ֺ����Ƕ����񡢵������������б�
- ��ʼһ��Э��ʱ��ִ�дӱ����÷�������ʼ����ʼ��һֱִ�е�yield return ��䣬���Ҹþ���뱻ִ����ϣ�֮��ÿ��Э�̱�����ʱ����Э����һ�η��ص�λ�ã�yield return��֮�����ִ��
- Э���ǵ��̵߳�
- ������ö���ű�����һ��Э�̣����԰����Э��д�ɾ�̬��
- Ŀǰ��Unity��û�м�㷽����ȡһ��������õ�Э����������һ����Э�̱���Щ�������



[Unity Э��(Coroutine)ԭ�����÷����](https://blog.csdn.net/xinzhilinger/article/details/116240688)

#### ��ô���unity��Э���е�yield�ؼ��֣�AI�𰸣�

��Unity��Э���У�`yield`�ؼ�����һ�������ָ����ڿ���Э�̵�ִ�����̡�Э����һ�ֿ�����ͣ�ͻָ�ִ�еĺ������������ں����ڲ�ִ��һ��һ�ε�ִ�У�������Ҫʱ��ͣ�ͻָ���

`yield`�ؼ��ֵ���������Э����ִ�е�`yield`���ʱ��ͣ����������Ȩ���ظ�Unity���¼�ѭ������Э���ٴα�����ʱ������`yield`���֮��Ĵ������ִ�С�

��Э����ʹ��`yield`�����Դ���һЩ�첽��Ϊ���ߵȴ�ĳЩ����������ټ���ִ�С����磬�����ʹ��`yield return new WaitForSeconds(time)`����Э����ͣһ��ʱ����ټ���ִ�С�

������һ���򵥵�ʾ����չʾ��`yield`�ؼ��ֵ��÷���


```csharp
public IEnumerator MyCoroutine()
{
    Debug.Log("Coroutine started");
    yield return new WaitForSeconds(2);
    Debug.Log("Coroutine resumed");
    yield return new WaitForSeconds(2);
    Debug.Log("Coroutine finished");
}
```
�������ʾ���У�`MyCoroutine()`����������һ��Э�̡���Э�̿�ʼִ��ʱ�������"Coroutine started"��Ȼ��ִ��`yield return new WaitForSeconds(2)`����ͣЭ�̵�ִ��2���ӣ������ؿ���Ȩ��Unity���¼�ѭ����2���Ӻ�Э�̻�ָ�ִ�У������"Coroutine resumed"���ٴ�ִ��`yield return new WaitForSeconds(2)`����ͣЭ�̵�ִ��2���ӣ������"Coroutine finished"�����Э�̽�����

ͨ��ʹ��`yield`�ؼ��֣����ǿ�����Э���д������ӵĿ������̣���ʵ���첽��Ϊ�͵ȴ��ض�����������ټ���ִ�еĹ��ܡ�

#### Э�̵�ִ�����̣�AI�𰸣�

Э�̵�ִ�����̿��Դ��¸���Ϊ���¼������裺

1. ����Э�̣���Unity��Update�������������ʵ��ĵط�����Э�̵ĺ�����
2. ִ��Э�̣���Э�̺����Ķ�����ʼִ�У�ֱ������`yield`��䡣��ִ�е�`yield`���ʱ��Э�̻���ͣ����������Ȩ���ظ�Unity���¼�ѭ����
3. �ж���������Э����ͣ�󣬻��`yield`����������������жϡ��������ĳ�����������緵��ֵ��Ϊnull���������ִ����һ�����������ִ�е�2����
4. ִ�к������룺����������㣬��`yield`���֮��Ĵ������ִ�С�
5. ����Э�̣����Э�̺����е����д��붼ִ����ϣ�Э�̽�����

������һ�������ʾ�����԰������Э�̵�ִ�����̣�


```csharp
public IEnumerator MyCoroutine()
{
    Debug.Log("Coroutine started");
    yield return new WaitForSeconds(2);
    Debug.Log("Coroutine resumed");
    yield return new WaitForSeconds(2);
    Debug.Log("Coroutine finished");
}

void Start()
{
    StartCoroutine(MyCoroutine());
}
```
�������ʾ���У�����Ϸ��ʼʱ�������`StartCoroutine(MyCoroutine())`������`MyCoroutine()`Э�̡���Э�̵ĺ������ڣ����Ȼ����"Coroutine started"��Ȼ��ִ��`yield return new WaitForSeconds(2)`����ͣЭ�̵�ִ��2���ӣ���������Ȩ���ظ�Unity���¼�ѭ����2���Ӻ�Э�̻�ָ�ִ�У������"Coroutine resumed"���ٴ�ִ��`yield return new WaitForSeconds(2)`����ͣЭ�̵�ִ��2���ӣ������"Coroutine finished"�����Э�̽�����

�����Э�̵�ִ�����̡�ͨ��ʹ��`yield`��䣬���ǿ�����Э����ʵ���첽��Ϊ�͵ȴ��ض�����������ټ���ִ�еĹ��ܡ�

#### ��һ��Э��Ƕ�׵����ӣ�Ȼ���������AI�𰸣�

�õģ�������һ��Э��Ƕ�׵����ӣ�


```csharp
public IEnumerator OuterCoroutine()
{
    Debug.Log("Outer Coroutine started");
    yield return StartCoroutine(InnerCoroutine());
    Debug.Log("Outer Coroutine resumed");
    // ��������
}

public IEnumerator InnerCoroutine()
{
    Debug.Log("Inner Coroutine started");
    yield return new WaitForSeconds(2);
    Debug.Log("Inner Coroutine resumed");
    // ��������
}

void Start()
{
    StartCoroutine(OuterCoroutine());
}
```
����������У�`OuterCoroutine()`��`InnerCoroutine()`������Ƕ�׵�Э�̡����ȣ�����Ϸ��ʼʱ������`StartCoroutine(OuterCoroutine())`������`OuterCoroutine()`Э�̡�Ȼ��`OuterCoroutine()`ִ�в����"Outer Coroutine started"�����ţ���������`InnerCoroutine()`�������������ͨ��`yield return`���ظ�`OuterCoroutine()`����ʱ��`OuterCoroutine()`��ִͣ�У���������Ȩ���ظ�Unity���¼�ѭ����

���¼�ѭ���У�Unity�������ȼ������е�Э�̣���ִ�����ȼ���ߵ�Э�̡�����������У����ȼ���ߵ�Э����`InnerCoroutine()`����ˣ�Unity��ִ��`InnerCoroutine()`�������"Inner Coroutine started"��Ȼ��`InnerCoroutine()`ִ��`yield return new WaitForSeconds(2)`����ͣ�Լ���ִ��2���ӣ���������Ȩ���ظ�Unity���¼�ѭ����

2���Ӻ�`InnerCoroutine()`�ָ�ִ�У������"Inner Coroutine resumed"��Ȼ��`InnerCoroutine()`����ִ�С���ʱ��Unity�������ȼ������е�����Э�̡�����`OuterCoroutine()`��`InnerCoroutine()`֮ǰ�������������ȼ����ܸ��ߣ�����Unity���ܻ�ִ��`OuterCoroutine()`��

���Unityѡ��ִ��`OuterCoroutine()`�������`yield return InnerCoroutine()`֮��Ĵ������ִ�У������"Outer Coroutine resumed"��Ȼ��`OuterCoroutine()`���Լ���ִ�к����Ĵ��롣

��ע�⣬�������ֻ��һ����ʾЭ��Ƕ�׵ļ�ʾ����ʵ�ʵ�Э��Ƕ�׿��ܻ�����ӣ�����ִ��˳�������������ض�������ͬ����ˣ��ڱ�дЭ��ʱ����Ҫ��ϸ���Ǻ͹���Э�̵�ִ�����̡�

#### ������Э��Ƕ�׺�ջ��һ����ϵ

�ǵģ�Э�̵�Ƕ��ִ����ջ�������еĹ�ϵ��������������У�����Ŀ�������ͨ��ջ�����ٵġ�ÿ���������ö��ᴴ��һ���µ�ջ֡�����а����˸õ��õľֲ������Ͳ����ȡ����������ý���ʱ������ջ֡�������٣��Ӷ��ͷ��ڴ档

Э�̵�Ƕ��ִ��Ҳ��ͨ��ջ�����ٵġ���һ��Э�̹���ʱ������ջ֡�ᱻ�����������Ա��ڻָ�ִ��ʱʹ�á���һ��Э��Ƕ�׵�����һ��Э��ʱ���ڲ�Э�̵�ջ֡�ᱻ�Ƶ����Э�̵�ջ�ϡ����ڲ�Э�̷���ʱ������ջ֡�������������Э�̽�����ִ�С�

��ˣ�Э�̵�Ƕ��ִ����Ҫ����ջ�Ĳ�������ĳЩ����£�������Ҫ�ֶ�����ջ�Ա����ڴ�й©����󡣵��ǣ�������ִ�������Ժ�����ʱ�������ṩ���Զ�����ջ�Ļ��ƣ�ʹ�ñ�дЭ�̱�ø��Ӽ򵥺Ͱ�ȫ��

#### �������Update������ʹ��Э�̻ᷢ��ʲô

�����Unity��Update������ֱ��ʹ��Э�̣����ܻᵼ��һЩ���⡣Update������Unity����ʱѭ����һ���֣�ÿ����Ϸ����ʱ���ᱻ���ö�Ρ������Update�����д���������Э�̣����ܻᵼ�´�����Э�̱����������٣��Ӷ����Ĵ�����ϵͳ��Դ����������Ϸ�����ܡ�

���⣬�����Update������ֱ��ʹ��Э�̣�����Ҫע��Э�̵�ִ��˳���ִ��ʱ�䡣����Э�̵�ִ��˳���ʱ���ǲ�ȷ���ģ����ܻᵼ��Э�̵�ִ��˳����Ԥ�ڲ�����������ĳЩ����³����������Ϊ��

��ˣ����齫Э�̵Ĵ��������������ʵ���λ�ã���������Ϸ��ʼʱ�������ض��ĺ����С��������Ա�����Update������Ƶ������������Э�̣������Ϸ�����ܺ��ȶ��ԡ�ͬʱ��Ҳ���Ը��õؿ���Э�̵�ִ��˳���ʱ�䣬ȷ��Э�̵���Ϊ����Ԥ�ڡ�

#### Э��һ����unity�ж�����ʵ����Щ����

Э����Unity�п�������ʵ�ֶ��ֹ��ܣ���Ҫ�������¼������棺

1. ��ʱ������ʹ��Э�̿��Դ���һ����ʱѭ�����ó�����һ��ʱ���ִ��ĳ�δ��롣����ͨ����Э���е���`WaitForSeconds`������ʵ�ֵġ�
2. �첽������Э�̿�������ʵ���첽����������������ͼƬ����ȡ�ļ��Ȳ���ʱ������ʹ��Э���������������̣߳���߳����Ч�ʡ�
3. ���ӵ���Ϸ�߼�������һЩ���ӵ���Ϸ�߼��������ɫ��Ϊ��AI���ߵȣ�ʹ��Э�̿����ô����������������ά����
4. ��Դ���أ�����Ϸ�����У���������Ҫ������Դ������ͼ����Ƶ�ȡ�ʹ��Э�̿��Ա����������̣߳���߳������Ӧ�ٶȡ�
5. ����ͨ�ţ���Unity�У�����ʹ��Э������������ͨ�ţ�����������Է���������Ϣ��������Ϊ�����ӳٶ��������߳�������

�ܵ���˵��Э�̿�������ʵ�ָ�����Ҫ�첽ִ�л���Ҫ����ִ��˳��ĳ���������������Ҫ�������߼�������ͨ�ŵĴ�����Ϸ�зǳ����á�

##### ʵ������
 ʵ�֣�Э��ʵ��UI�ı�������ʾ

 ```C#
 public class ienumeratorDemo : MonoBehaviour
{
    
    public Text textLable;
    private string showText;
    private string fullText;
    private bool isPrint;
    public float textShowSpeed;
    private void Start()
    {
        showText = "";
        fullText= "̸Ц��ǿߣ�ҷ�����";
        textLable.text = "";
        isPrint = false;
    }
    /// <summary>
    /// ʹ��Э��ʵ���ַ������ַ�һ��һ����ӡ
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private IEnumerator ShowTextOneByOne(string text)
    {
        showText = "";
        for(int i = 0; i < text.Length; i++)
        {
            showText+=text[i];
            textLable.text = showText;
            yield return new WaitForSeconds(1f/textShowSpeed);
        }
        isPrint = false;
    }
    private void OnGUI()
    {
        if (GUILayout.Button("PrintText")&&!isPrint) {
            isPrint = true;
            StartCoroutine(ShowTextOneByOne(fullText));
        }
    }
}
 ```
##### ʵ������
ʵ�֣�������·��ѭ���ƶ���·���㴦��ת������ʹ��Э��ʵ��

```C#
public class ienumeratorDemo : MonoBehaviour
{
    //·����ĸ��ڵ�
    public Transform wpsObj;
    //·���㼯��
    private List<Vector3> wps;
    private bool isLoop;
    public float moveSpeed;
    public float rotateSpeed;
    private void Start()
    {
        WpsInit();
        isLoop = false;
    }
    
    private void WpsInit()
    {
        wps = new List<Vector3>();
        for(int i=0; i<wpsObj.childCount; i++)
        {
            wps.Add(wpsObj.GetChild(i).transform.position);
        }
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Loop") && !isLoop) {
            StartCoroutine(TravelPoint());
            isLoop = true;
        }
    }

    private IEnumerator TravelPoint()
    {
        for (int i = 0; i < wpsObj.childCount; i++)
        {
            yield return StartCoroutine(CubeRotate(i));
            yield return StartCoroutine(CubeMove(i));
            if (i == wpsObj.childCount - 1) i = -1;
            
        }
    }

    private IEnumerator CubeRotate(int index)
    {
        if (wps[index]!= transform.position)//�����ڳ�ʼλ��ʱ��lookquaternionΪ0��bug��
                                            //�����Ӹ��жϣ��ڳ�ʼλ��ʱ��Quaternion.LookRotation���ᱨ��ʾ��ϢLook rotation viewing vector is zero
        {
            Quaternion qua = Quaternion.LookRotation(wps[index] - transform.position, Vector3.up);
            while (transform.rotation != qua)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, qua, rotateSpeed*Time.deltaTime);
                yield return null;
            } 
        }
        
    }

    private IEnumerator CubeMove(int index)
    {
        while (transform.position != wps[index])
        {
            transform.position = Vector3.MoveTowards(transform.position, wps[index], moveSpeed*Time.deltaTime);
            yield return null;
        }
    }   
}
```

##### ����Э��Ƕ��

�ɲμ�����AI����Э��Ƕ�׵Ľ��͡����Ϸ�ʵ�������У���
```C#
    private IEnumerator TravelPoint()
    {
        for (int i = 0; i < wpsObj.childCount; i++)
        {
            yield return StartCoroutine(CubeRotate(i));
            //...
        }
    }
```

ע�⣬��ִ�е�`yield return StartCoroutine(CubeRotate(i));`ʱ���������ͣ���ȴ�Э��StartCoroutine(CubeRotate(i))ȫ��ִ����ϣ���ִ�к�������

### Ѱ·ϵͳ

#### �����÷�
- ������Ѱ·������
    - ·��Ѱ·����Ҫ���з���·�㣬ʹ������·���˶�
    - ��Ԫ��Ѱ·
    - **����Mesh ��Ѱ·**

����Ѱ·�Ĳ��裨unity2022.3�汾����

1. �������й̶����������年ѡstatic
1. �決Ѱ·����
1. ���ƶ��Ķ������NavMeshAgent�����unityͨ�������ʵ��Ѱ·
1. ���ö�����ӽű�ʵ��Ѱ·

#### NavMesh��������

##### NavMeshAgent����

��ͬ�汾�Ľ�����ܲ�ͬ�����������ͻ�������
[NavMeshAgent����_unity�ĵ�](https://docs.unity.cn/cn/2022.3/Manual/class-NavMeshAgent.html)

<table>
<colgroup>
<col style="text-align:left;">
<col style="text-align:left;">
</colgroup>

<thead>
<tr>
	<th style="text-align:left;">����</th>
	<th style="text-align:left;">����</th>
</tr>
</thead>

<tbody>
<tr>
	<td style="text-align:left;" colspan="2"><em>Agent Size</em></td>
</tr>
<tr>
	<td style="text-align:left;"><strong>Radius</strong></td>
	<td style="text-align:left;">����İ뾶�����ڼ����ϰ�������������֮�����ײ��</td>
</tr>
<tr>
	<td style="text-align:left;"><strong>Height</strong></td>
	<td style="text-align:left;">����ͨ��ͷ���ϰ���ʱ����ĸ߶ȼ�϶��</td>
</tr>
<tr>
	<td style="text-align:left;"><strong>Base offset</strong></td>
	<td style="text-align:left;">��ײԲ��������ڱ任���ĵ��ƫ�ơ�</td>
</tr>
<tr>
	<td style="text-align:left;" colspan="2"><em>Steering</em></td>
</tr>
<tr>
	<td style="text-align:left;"><strong>Speed</strong></td>
	<td style="text-align:left;">����ƶ��ٶȣ������絥λ/���ʾ����</td>
</tr>
<tr>
	<td style="text-align:left;"><strong>Angular Speed</strong></td>
	<td style="text-align:left;">�����ת�ٶȣ���/�룩��</td>
</tr>
<tr>
	<td style="text-align:left;"><strong>Acceleration</strong></td>
	<td style="text-align:left;">�����ٶȣ������絥λ/ƽ�����ʾ����</td>
</tr>
<tr>
	<td style="text-align:left;"><strong>Stopping distance</strong></td>
	<td style="text-align:left;">������Ŀ��λ�õľ���ﵽ��ֵʱ������ֹͣ��</td>
</tr>
<tr>
	<td style="text-align:left;"><strong>Auto Braking</strong></td>
	<td style="text-align:left;">���ô����Ժ󣬴����ڵ���Ŀ��ʱ�����١�����Ѳ�ߵ���Ϊ����������£�����Ӧ�ڶ����֮��ƽ���ƶ���Ӧ���ô�����</td>
</tr>
<tr>
	<td style="text-align:left;" colspan="2"><em>Obstacle Avoidance</em></td>
</tr>
<tr>
	<td style="text-align:left;"><strong>Quality</strong></td>
	<td style="text-align:left;">�ϰ�������������ӵ�д������������ͨ�������ϰ������������ʡ CPU ʱ�䡣������������Ϊ�ޣ���ֻ�������ײ�������᳢�������������������ϰ��</td>
</tr>
<tr>
	<td style="text-align:left;"><strong>Priority</strong></td>
	<td style="text-align:left;">ִ�б���ʱ���˴����������ȼ��ϵ͵Ĵ�����ֵӦ�� 0�C99 ��Χ�ڣ����нϵ͵����ֱ�ʾ�ϸߵ����ȼ���</td>
</tr>
<tr>
	<td style="text-align:left;" colspan="2"><em>Path Finding</em></td>
</tr>
<tr>
	<td style="text-align:left;"><strong>Auto Traverse OffMesh Link</strong></td>
	<td style="text-align:left;">Set to true to automatically traverse OffMesh links. You should turn this off when you want to use animation or some specific way to traverse OffMesh links.</td>
</tr>
<tr>
	<td style="text-align:left;"><strong>Auto Repath</strong></td>
	<td style="text-align:left;">���ô����Ժ󣬴����ڵ��ﲿ��·��ĩβʱ�����ٴ�Ѱ·����û�е���Ŀ���·��ʱ��������һ������·��ͨ����Ŀ������Ŀɴ�λ�á�</td>
</tr>
<tr>
	<td style="text-align:left;"><strong>Area Mask</strong></td>
	<td style="text-align:left;">Area Mask �����˴�����Ѱ·ʱ�����ǵ�<a href="nav-AreasAndCosts.html">��������</a>����׼��������е�������決ʱ��������ÿ�������������͡����磬�ɽ�¥�ݱ��Ϊ�����������ͣ�����ֹĳЩ��ɫ����ʹ��¥�ݡ�</td>
</tr>
</tbody>
</table>

###### tips
- ����NavMesh�����������PackageManager�а�װNavigation��
- �°汾��Navgation��������Bake��ť����Ҫ�ھ�̬�����Ķ��������NavMeshSurface���
- 
![��������01](unityNoteAssert/��������01.png)

- **����̬�����Ķ�������Layer������NavMeshSurface��Object Collect�����ú決�Ķ����Layer**
    - ��Collect Objects��ΪAllGameObject��IncludeLayer��ΪEverythingʱ���決����������������������ɫģ��Ҳ��������������決��
    - ![�決01](unityNoteAssert/�決01.png)
    - ��ȷ�������ǣ�����̬����layer��Ϊenvironment������Include Layer��ΪEnvironment

- ע�⣺��̬��������決�󣬺決�����Ѿ����ˣ��뾲̬�����Ƿ񼤻��޹ء���ʱ��ʹ���þ�̬�������󣬺決������Ȼ���ڣ�����ʱ��Ȼ���Ե���
- ʵ�����£�
    - ������֮���һ�����������決
    - ![����02](unityNoteAssert/����02.png)
    - �������������ã�����
    - ![����03](unityNoteAssert/����03.png)

    
#### NavMeshModifier

![����04](unityNoteAssert/����04.png)

Ϊ���決�ľ�̬������Ӹ�����󣬿����޸ĸ��������������AreaType����walkable��jump�ȡ�����Navigation�������������costֵ���ɵ���Ѱ·����agent��Ѱ·��Ϊ

![����05](unityNoteAssert/����05.png)

֮����agent��AreaMaskѡ����ѡ����Ӧ�����򣬼���ʵ��Ѱ·�ĵ���
![����07](unityNoteAssert/����07.png)

ע�⣺NavMeshSurfaceֻ��Ҫ��һ���Ϳ����ˣ�Ч�����£�![����08](unityNoteAssert/����08.png)


#### ����Ѱ·����

- A*Ѱ·
- SamplePath

### ��unity�л���

- Debug.DrawLine();
   - ֻ����Scene����ʾ�������ڵ���
   - ��Ҫʹ����Game����ʾ���뼤��Game��Gizmos
- ʹ��LineRender�����Game�л���


---

## 2DGame

#### ʹ��TileMap����Ƭ��ͼ�����ͼ

- ���TileMap
  - ���2D����2D object -> TileMap
  - ��ͬ��TileMap��Ӧ�в�ͬ����Ƭ��״���������Ρ������ε�
- ��δ���Tile��Ƭ
  - Asset���Ҽ�->2D->����Tile��Դ
  - ��Tile���Sprite����
- Tile��������
  - Animation Tile��ͨ��������Ƭ��Ӷ��sprite�����л�������ʵ��һ����Ƭ�ϵĶ���Ч��
  - Rule Tile��������ģʽ
    - single�����һ��sprite��ͬ��ͨ��Ƭ
    - animation����Ӷ��sprite��ͬAnimation Tile
    - random����Ӷ��sprite��ʹ�ø�Tile��TileMap�����Tileʱ���������ѡȡSprite������ʾ
- ʹ��Tile
  - ��window -> 2D -> Tile Palette��Ƭ��ɫ��
  - ��Tile��ק����ɫ����
  - �ڵ�ɫ����ѡ��Ҫʹ�õ���Ƭ����TileMap�ϵ���������

![��Ƭ��ɫ��](unityNoteAssert/��Ƭ��ɫ��.png)

ps:markdown��ͼƬ·��ֻ֧�����·�����ʽ���ͼƬ������md�ļ���ͬһ�ļ�����

###### tips
��Inspector���Ͻ��С��������������������ǰ���ڣ��ڵ����������ʱ�����л��������Ĵ���

![С����01](unityNoteAssert/С����01.png)

#### ����
����AnimationClip֮�󣬳��˿����ڶ������޸Ķ����transform���������޸�������������ʵ�ֲ�ͬ����Ч��������޸�sprite

![����00](unityNoteAssert/����00.png)

##### Sprite����������

- 2����2D��棬���ҷ��򣬿ɽ�ʹ��һ�������sprite���������ͨ��Sprite�ľ���ʵ�֣���SpriteRender��Flip
- 4����2D���ӣ����ö����ı�spriteʵ��
- 8����2.5D���ӣ�һ��Ϊ3D��Ⱦ��2D��3��2���ù��߻���ÿһ��������
- ���෽�򡣡���

![���鶯������](unityNoteAssert/���鶯������.png)

#### ��ͷ����

����Cinemachine����ʹ�������������ʵ�ָ���

##### ʹ��������������ȡ�����λ��
���⣺��ʹ��Cinemachine֮ǰ������ȷ��ȡ��Ļ����תΪ�������꣬ʹ�ú�Camera.main.ScreenToWorldPoint(Input.mousePosition)��ȫ����Ч����������ʲô���ô����˻���CinemachineҪʹ�������ķ�����
�����
  - ����1��������� Projection Ϊ Orthographic��������ģʽʱ��Camera.main.ScreenToWorldPoint ת��������Ҫ����Ŀ��㵽�������z�᷽����룬���������Ļ��ת�����ͽ�ɫ��ͬzֵ������㣬����Ҫ�����ɫz-�����z��ֵ���������ֵ�滻�� Input.mousePosition ��zֵ��
  - ����2��ʹ�����߼��λ��

[ʹ��Cinemachine����Ļ����ת��������λ�ò���ȷ����Ч](https://developer.unity.cn/ask/question/632fce8aedbc2a001e6b5dcd)


##### 2D��ɫͷ��Ѫ������

[ʹ��Slider�������Ѫ��](#ʹ��Slider�����������Ѫ���ķ���)
- ʹ��Slider����Ѫ��������������Text����ͷ����ʾ���ǳƵȡ�
- ��Ѫ��hpBarΪ�����������ֻ��һ����ɫ����ôֻ��Ҫ��Ѫ�����ٽ�ɫ��λ�ò���ʾ�ڽ�ɫ�Ϸ����ɣ�Ѫ���ű��������£�

```csharp
     /// <summary>
    /// ���ٵ�Ŀ��
    /// </summary>
    public Transform target;
    /// <summary>
    /// λ�õ�ƫ��ֵ
    /// </summary>
    private float offset;
    private Slider hpBar;
    private Camera mainCam;
    private void Start()
    {
        mainCam = GetComponent<Camera>();
        hpBar=GetComponent<Slider>();
    }

    private void Update()
    {
        if (target != null)
        {
            offset = (target.GetComponent<BoxCollider2D>().size.y/2)*target.transform.localScale.y+0.5f;
            
            //���Canvas����Ⱦģʽ��overlayģʽ������Ҫ������ת��������������ת��Ϊ��Ļ����
            //transform.position= RectTransformUtility.WorldToScreenPoint(Camera.main,target.position + new Vector3(0, offset,0));
            
            //���Canvas����Ⱦģʽ��Cameraģʽ����ֱ��ʹ��Ŀ��λ�ý��и��ټ���
            transform.position = target.position+new Vector3(0,offset,0);
            

            hpBar.value = enemyMovementLogic.hp;
            hpBar.maxValue = enemyMovementLogic.maxHp;
        }      
    }
```

����������ж����ɫ�����Ѫ��ʱ����Ҫʹ�ýű������������ЩѪ����

���賡�����£������ɸ��������ɵ㣬���һ��ʱ�����ɵ��ˡ�

Ѫ������˼·���£�

- ��������һ��Canvas�����������ɵ�Ѫ����ʹ��HpManager�ű�����Ѫ��������
- ���ɵ���ʱ��ͬʱʹ��HpManager����һ��Ѫ��������������ΪѪ����׷����ĻĿ��
- ��������ʱ������Ѫ���͵��˶���

###### 2DѪ������Ĺ�β����

����ÿ�����ɵ��˶�Ҫ���´���Ѫ�������ܻ��������ܣ�
�����ڳ�ʼ��ʱ����һ��������Ѫ��������Ϊ����״̬��ʹ��һ�����д洢��
�����ɵ���ʱ���Ӷ�����ȡһ��Ѫ����
����������ʱ����Ҫ��Ѫ����׷��Ŀ����Ϊnull��������Ѫ���Żض����С�

����˵�����ɵ��˵�ʱ��Ҳ����������˼·����������ʱ��ȥ���ٶ��󣬶��Ƿŵ�һ��λ�á��е����̳߳ص�˼�룬Ҳ������ж���أ�

##### 3D��ɫѪ������
Canvas����ȾģʽΪWorld Space,ʹSlide�䵱Ѫ����λ���ڽ�ɫ�Ϸ�����

###### ����Ԥ�����ϵĽű�

Ԥ������صĽű��У����д��public�Ķ�����Inspector��������޷�������ק�ϵģ���ΪԤ��������������Ŀ���ǵ�����������
��ק�Ķ������ڵ�������������unity������������ק�������Ҫ��Ԥ����Ľű��л�ȡ����ȣ�����ͨ��Gameobject�ľ�̬�������в��Ҷ���

### ����Ч��
ʹ��**cloth**�����**skinned mesh renderer**���

![�������](unityNoteAssert/�������.png)

���cloth����ı༭��ť�����Խ����ϵ�ĳ����̶���һ��λ�ã��Ӷ�ʵ������Ʈ���Ч��

���ϰ󶨵�������ʽ����������ٷ��ĵ���

- max distance�����ò��Ͼ����Ӧ�󶨵�������룬����Ϊ0����õ�Ĳ��ϲ����´�
![���ϰ�](unityNoteAssert/���ϰ�.png)
- surface penetration ����Ƕ��


### ��Ƶ����
ʹ��videoPlater���

![��Ƶ�������](unityNoteAssert/��Ƶ�������.png)

### ��պ�

�����պ���������ã����window->rendering->linghting_environment��

### Unity�����Ż�֮�ڵ��޳�

- ���Ƚ����Ż��Ķ�����Ϊ��̬occluder static
- window->rendering->occlusion culling �������úͺ決

�ο�����[Unity�����Ż�֮�ڵ��޳�](https://blog.csdn.net/qq_40513792/article/details/115078009)

#### Unity�����ƾ�ͷ
�ο�����[Unity ���� ֮ ������ ����������Camera������ת���ƶ��� fov �ļ�ʹ������](https://blog.csdn.net/u014361280/article/details/113689370)

#### Cinemachineʵ�־�ͷ����

���Ա��⾵ͷ��ǽ�ȣ��ǳ�ʵ�ã�����ѧϰ

###### tips
Unity�г�����������������ʱ��Ҫ���пո��确body up��


### Layer��LayerMask����Ͳ����֣�
Unity��Layer�Ĵ洢����ö����Ĵ洢������������������Layer��ֵָ�������ӣ����Ϊ32��

|Layer ����|LayeMask�����value�ֶ�ֵ|������|
|---|---|---|
|0|0|00000000000000000000000000000000|
|1|2|00000000000000000000000000000001|
|2|4|00000000000000000000000000000010|
|3|6|00000000000000000000000000000100|
|4|16|00000000000000000000000000001000|
|5|32|00000000000000000000000000010000|
|6|64|00000000000000000000000000100000|
|7|128|00000000000000000000000001000000|
|...|...|...|

���ԣ���LayerMaskת��ΪLayer�ķ���Ϊ��ʹ��log()����layermask.value����2Ϊ�׵Ķ���������

```csharp
    /// <summary>
    /// ��layermaskת��Ϊlayer����ֵ
    /// </summary>
    /// <param name="layerMask"></param>
    /// <returns></returns>
    private int LayerMask2LayerIndex(LayerMask layerMask) {
        return (int)Mathf.Log(layerMask.value,2);
    }
```

����LayerMask��������̬����

```csharp
// ��Layer������ת��ΪLayermask.valueֵ
public static int NameToLayer(string layerName)
// layermask.valueת��Ϊlayer������
public static string LayerToName(int layer);
```
---
#### �ȿ� Unity Hub���º���Ŀ��ʧ
- ������Ŀ�������ù��ڵ��йܷ���Gitee������GitHub��Ϊ�ֿ⡣
- ������Ϊ��ʱ�����������Ŀ�ļ�ǧ��Ҫ����Unity hubĿ¼�¡�
---

##### Unity�м�ʱ���ӳ�ִ�й��ܵ�ʵ��
###### ����һ ��Update��ʵ�ּ�ʱ

PlayerAttackLogic�ű�����������߼�,��������:

```c#
    private void Start(){
        //Ϊ�˱�֤��������������һ�Σ���timer��ʼ��ΪshotDeltaTime
        //shotDeltaTimeΪ��Ƶļ��ʱ��
        timer=shotDeltaTime;
        //�����timer=0,����������Ҫ�ȴ�shotDeltaTime�ڿ�ʼ����������󲻷�
    }

    private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if (timer >= shotDeltaTime) {
                    Attack();
                    timer = 0;
                }
                else
                {
                    timer+=Time.deltaTime;
                }
                //InvokeRepeating(nameof(Attack), 0, shotDeltaTime);
            }
            else
            {
                timer = shotDeltaTime;
            }
        }
```

һ��ʼ��˼·�ǣ���������������InvokeRepeating()��������Attack�������Դ�ʵ��������������Ҫע����ǣ������Update��ֱ��ʹ��Invoke��InvokeRepeating������ÿһ֡����ִ��һ��Invoke����Update��ֱ�ӿ���Э��ͬ��
���Ը�Ϊֱ��ʹ��һ����ʱ������timer���м�ʱ��

���Ҫ��Update��ʹ��Invoke����Э�̣���Ҫ��һ������ֵ��Ϊ���أ�����֤Invoke��Э��ִֻ��һ�Ρ�

###### ������ ʹ��Invoke����ʵ�ּ�ʱ

*������*

**ʹ��Invoke�޷��������**

###### ������ ʹ��Э��ʵ�ּ�ʱ

ʵ������Ҫ�����ƵĶ������ʵ��һ���ӳٻ��ն���Ĺ��ܣ���������

```C#
    public void DestroyObject(GameObject obj,float delay)
        {        
            StartCoroutine(DestroyObject_Delay(obj,delay));
        }
    private IEnumerator DestroyObject_Delay(GameObject obj,float delaytime)
        {
            yield return new WaitForSeconds(delaytime);
            DestroyObject(obj);
        }
```

ע�⣺�����Ļ��ն���ķ���`DestroyObject(obj);`����Э����ִ��

###### ������ DoTween

*������*

�ο�����[Unity��ʱִ�е�n�ַ���](https://blog.csdn.net/hzhnzmyz/article/details/118422189)

##### Ͷ����Ӱ�ͽ�����ӰͶ��

��ʱ������ĳһ������Ͷ����Ӱ�����߲����������Ͻ��������������Ӱ�������޸�Mesh Render��������ʵ�֡�

- Cast Shadows	ָ���ں��ʵĹ�Դ������������ʱ�����Ƿ��Լ����Ͷ����Ӱ��
- Receive Shadows	���ô�ѡ���ʹ������ʾ�κ�Ͷ���������ϵ���Ӱ������ʹ�ý���������ͼʱ��֧�����ѡ�

�ο�[������Ⱦ�� (Mesh Renderer)](https://docs.unity.cn/cn/2019.4/Manual/class-MeshRenderer.html#lighting)

###### ��Ϸ��������
```csharp
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif

```