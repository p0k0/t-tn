using System;
using System.Collections.Generic;
using System.Linq;

namespace Storage.Impl
{
    public class PhoneNumbersStorage
    {
        private RefDataFactory _factory;
        private RefDataStorage _storage;
        private IDictionary<RefData, IEnumerable<string>> _phoneBook;

        public PhoneNumbersStorage()
        {
            _factory = new RefDataFactory();
            _storage = _factory.CreateStorage();
            _phoneBook = new Dictionary<RefData, IEnumerable<string>>();
        }

        public void Save(string number, string userName)
        {
            var phoneDataNode = _storage.Save(number);
            var users = default(IEnumerable<string>);

            if (_phoneBook.TryGetValue(phoneDataNode, out users))
            {
                var editableUsers = ((HashSet<string>)users);
                if (!editableUsers.Contains(userName))
                    editableUsers.Add(userName);
            }
            else
            {
                _phoneBook.Add(phoneDataNode, new string[] { userName });
            }
        }

        public IEnumerable<string> FindByNumber(string number)
        {
            return _storage.FindCorrelations(number);
        }

        public IEnumerable<string> FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
