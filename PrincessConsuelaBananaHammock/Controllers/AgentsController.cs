namespace PrincessConsuelaBananaHammock.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using PrincessConsuelaBananaHammock.Models;

    [ApiController]
    [Route("api/[controller]")]
    public class AgentsController : ControllerBase
    {
        // GET: api/Agents
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var agents = await GetAgents();
            return Ok(agents);
        }

        // GET: api/Agents/5
        [HttpGet("{id}", Name = "GetAgent")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var agents = await GetAgents();
            var agent = agents.FirstOrDefault(x => x._Id == id);

            if (agent != null)
            {
                var customers = await GetCustomers();
                agent.Customers = customers.Where(x => x.Agent_id == agent._Id);
            }

            return Ok(agent);
        }

        // POST: api/Agents
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Agent agent)
        {
            if (agent is null)
                return BadRequest();

            var agents = await GetAgents();

            agents.Add(agent);
            SaveToAgentsFile(agents);

            return Ok();
        }

        // POST: api/Agents/5/Customer
        [HttpPost("{id}/Customer")]
        public async Task<IActionResult> PostAsync([FromBody] Customer customer)
        {
            if (customer is null)
                return BadRequest();

            var customers = await GetCustomers();

            customers.Add(customer);
            SaveToCustomersFile(customers);

            return Ok();
        }

        // PUT: api/Agents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Agent agent)
        {
            if (agent is null)
                return BadRequest();

            var agents = await GetAgents();
            for (int i = 0; i < agents.Count(); i++)
            {
                if (agents[i]._Id == id)
                {
                    agents[i] = agent;
                }
            }

            SaveToAgentsFile(agents);

            return Ok();
        }

        // PUT: api/Agents/5/Customer
        [HttpPut("{id}/Customer")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Customer customer)
        {
            if (customer is null)
                return BadRequest();

            var agents = await GetAgents();
            var agent = agents.FirstOrDefault(x => x._Id == id);

            var customers = await GetCustomers();
            for (int i = 0; i < customers.Count(); i++)
            {
                if (customers[i].Agent_id == agent._Id)
                {
                    customers[i] = customer;
                }
            }

            SaveToCustomersFile(customers);

            return Ok();
        }

        // DELETE: api/Agents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgentAsync(int id)
        {
            var agents = await GetAgents();

            var agent = agents.FirstOrDefault(x => x._Id == id);
            if (agent != null)
            {
                agents.Remove(agent);
                SaveToAgentsFile(agents);
            }

            return Ok();
        }

        // DELETE: api/Agents/5/Customer
        [HttpDelete("{id}/Customer/{customerId}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id, int customerId)
        {
            var customers = await GetCustomers();

            var customer = customers.FirstOrDefault(x => x._Id == customerId);
            if (customer != null)
            {
                customers.Remove(customer);
                SaveToCustomersFile(customers);
            }

            return Ok();
        }

        // should be in a service class
        private async Task<IList<Agent>> GetAgents()
        {
            var json = System.IO.File.ReadAllText("Data/agents.json");
            var results = await Task.Run(() => JsonConvert.DeserializeObject<IList<Agent>>(json));
            return results;
        }

        // should be in a service class
        private async Task<IList<Customer>> GetCustomers()
        {
            var json = System.IO.File.ReadAllText("Data/customers.json");
            var results = await Task.Run(() => JsonConvert.DeserializeObject<IList<Customer>>(json));
            return results;
        }

        // should be in a service class
        private async void SaveToAgentsFile(IList<Agent> agents)
        {
            var output = await Task.Run(() => JsonConvert.SerializeObject(agents, Formatting.Indented));
            System.IO.File.WriteAllText("Data/agents.json", output);
        }

        // should be in a service class
        private async void SaveToCustomersFile(IList<Customer> customers)
        {
            var output = await Task.Run(() => JsonConvert.SerializeObject(customers, Formatting.Indented));
            System.IO.File.WriteAllText("Data/customers.json", output);
        }
    }
}